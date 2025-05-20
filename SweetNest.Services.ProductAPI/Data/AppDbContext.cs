using Microsoft.EntityFrameworkCore;
using SweetNest.Services.ProductAPI.Models;

namespace SweetNest.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "巧克力脆片餅乾",
                Price = 120,
                Description = "香脆餅乾中融合濃郁巧克力，入口即化，甜而不膩。",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "餅乾"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "法式檸檬塔",
                Price = 250,
                Description = "清爽檸檬內餡搭配酥脆塔皮，酸甜平衡，口感絕佳。",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "蛋糕"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "焦糖布丁",
                Price = 80,
                Description = "綿密滑順的布丁，配上香濃焦糖醬，每一口都療癒。",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "點心"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "經典巧克力蛋糕",
                Price = 300,
                Description = "濃厚巧克力香氣，細緻口感，適合每一個愛甜點的人。",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "蛋糕"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "楓糖可頌",
                Price = 150,
                Description = "層層酥脆的可頌淋上香甜楓糖，外酥內軟，回味無窮。",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "麵包"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "經典蘋果派",
                Price = 250,
                Description = "香甜蘋果餡搭配酥脆派皮，口感豐富，經典不敗之選。",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "派塔類"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                Name = "巧克力甜甜圈",
                Price = 110,
                Description = "蓬鬆甜甜圈淋上濃郁巧克力醬，甜而不膩，讓人愛不釋口。",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "甜甜圈"
            });

        }
    }
}
