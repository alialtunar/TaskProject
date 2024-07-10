using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Clothing" },
                    { 4, "Toys" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 9, 4, "Remote-controlled toy car", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.civilim.com%2Fcan-oyuncak-surtmeli-araba-kirmizi-kms-019-krm&psig=AOvVaw0bOQd4UevdHzL93wgaGeC2&ust=1720708138609000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCJiW4b3XnIcDFQAAAAAdAAAAABAJ", "Toy Car", 45.00m },
                    { 10, 3, "Light and stylish summer dress", "https://i.ebayimg.com/images/g/OoIAAOSwqMtdmUEp/s-l1600.jpg", "Summer Dress", 85.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
