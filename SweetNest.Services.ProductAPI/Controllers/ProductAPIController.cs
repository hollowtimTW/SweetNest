using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetNest.Services.ProductAPI.Data;
using SweetNest.Services.ProductAPI.Models;
using SweetNest.Services.ProductAPI.Models.Dto;
using SweetNest.Services.ProductAPI.Service;

namespace SweetNest.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        private readonly ICloudStorageService _cloudStorageService;
        private readonly string _filePath;

        public ProductAPIController(AppDbContext db, IMapper mapper, ICloudStorageService cloudStorageService, IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
            _cloudStorageService = cloudStorageService;
            _filePath = configuration["GcpSettings:CloudStorage:FilePath"];
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Product> objList = _db.Products.ToList();
                _response.Result = _mapper.Map<IEnumerable<ProductDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Product obj = _db.Products.First(u => u.ProductId == id);
                _response.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Post(ProductDto ProductDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(ProductDto);
                _db.Products.Add(product);
                _db.SaveChanges();

                if (ProductDto.Image != null)
                {
                    string fileName = product.ProductId + "_" + Guid.NewGuid().ToString("N") + Path.GetExtension(ProductDto.Image.FileName);
                    product.ImageUrl = await _cloudStorageService.UploadFileAsync(fileName, _filePath, ProductDto.Image);
                    product.ImagePath = $"{_filePath}/{fileName}"; 
                }
                else
                {
                    product.ImageUrl = "https://placehold.co/600x400";
                }

                _db.Products.Update(product);
                _db.SaveChanges();
                _response.Result = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Put(ProductDto ProductDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(ProductDto);

                if (ProductDto.Image != null)
                {
                    if (!string.IsNullOrEmpty(product.ImagePath))
                    {
                        await _cloudStorageService.DeleteFileAsync(product.ImagePath, _filePath);
                    }
                    string fileName = product.ProductId + "_" + Guid.NewGuid().ToString("N") + Path.GetExtension(ProductDto.Image.FileName);
                    product.ImageUrl = await _cloudStorageService.UploadFileAsync(fileName, _filePath, ProductDto.Image);
                    product.ImagePath = $"{_filePath}/{fileName}";
                }

                _db.Products.Update(product);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                Product product = _db.Products.First(u => u.ProductId == id);
                if (!string.IsNullOrEmpty(product.ImagePath))
                {
                    await _cloudStorageService.DeleteFileAsync(product.ImagePath, _filePath);
                }
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
