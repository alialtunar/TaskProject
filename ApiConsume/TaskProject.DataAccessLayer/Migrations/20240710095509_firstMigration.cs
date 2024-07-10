using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "High performance laptop", "https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c08478684.png", "Laptop", 1500.00m },
                    { 2, 1, "Latest model smartphone", "https://cdn.cimri.io/image/1200x1200/apple-iphone-15-5g-128gb_865272811.jpg", "Smartphone", 999.00m },
                    { 3, 1, "Noise cancelling headphones", "https://enteknoloji.com.tr/cdn/shop/files/air-3-bluetooth-kulaklik-1.1.png?v=1693815672&width=2048", "Headphones", 199.00m },
                    { 4, 1, "10 inch tablet", "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/lenovo/thumb/untitled-1-3_large.jpg", "Tablet", 400.00m },
                    { 5, 1, "4K monitor", "https://www.casper.com.tr/uploads/2023/09/casper-nirvana-238-monitor-03_op.webp", "Monitor", 350.00m },
                    { 6, 2, "Interesting book", "https://www.panelkirtasiye.com/productimages/468746/big/9786258431254_1.jpg", "Book 1", 20.00m },
                    { 7, 2, "Interesting book", "https://img.kitapyurdu.com/v1/getImage/fn:5847593/wh:true/wi:800", "Book 2", 60.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
