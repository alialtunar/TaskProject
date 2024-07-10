using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migThird : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://cdn.civilim.com/productimages/353321/big/86992623400652.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.civilim.com%2Fcan-oyuncak-surtmeli-araba-kirmizi-kms-019-krm&psig=AOvVaw0bOQd4UevdHzL93wgaGeC2&ust=1720708138609000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCJiW4b3XnIcDFQAAAAAdAAAAABAJ");
        }
    }
}
