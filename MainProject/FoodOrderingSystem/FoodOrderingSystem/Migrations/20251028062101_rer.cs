using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class rer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DishImage",
                table: "Dish");

            migrationBuilder.AddColumn<string>(
                name: "DishImagePath",
                table: "Dish",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DishImagePath",
                table: "Dish");

            migrationBuilder.AddColumn<byte[]>(
                name: "DishImage",
                table: "Dish",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
