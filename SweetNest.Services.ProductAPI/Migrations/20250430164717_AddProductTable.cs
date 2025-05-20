using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SweetNest.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImagePath", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "餅乾", "香脆餅乾中融合濃郁巧克力，入口即化，甜而不膩。", null, "https://placehold.co/600x400", "巧克力脆片餅乾", 120.0 },
                    { 2, "蛋糕", "清爽檸檬內餡搭配酥脆塔皮，酸甜平衡，口感絕佳。", null, "https://placehold.co/600x400", "法式檸檬塔", 250.0 },
                    { 3, "點心", "綿密滑順的布丁，配上香濃焦糖醬，每一口都療癒。", null, "https://placehold.co/600x400", "焦糖布丁", 80.0 },
                    { 4, "蛋糕", "濃厚巧克力香氣，細緻口感，適合每一個愛甜點的人。", null, "https://placehold.co/600x400", "經典巧克力蛋糕", 300.0 },
                    { 5, "麵包", "層層酥脆的可頌淋上香甜楓糖，外酥內軟，回味無窮。", null, "https://placehold.co/600x400", "楓糖可頌", 150.0 },
                    { 6, "派塔類", "香甜蘋果餡搭配酥脆派皮，口感豐富，經典不敗之選。", null, "https://placehold.co/600x400", "經典蘋果派", 250.0 },
                    { 7, "甜甜圈", "蓬鬆甜甜圈淋上濃郁巧克力醬，甜而不膩，讓人愛不釋口。", null, "https://placehold.co/600x400", "巧克力甜甜圈", 110.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
