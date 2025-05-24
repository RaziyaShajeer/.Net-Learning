using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class dishtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestaurantImage",
                table: "RestaurantProfile",
                newName: "RestaurantImages");

            migrationBuilder.RenameColumn(
                name: "DishImage",
                table: "Dish",
                newName: "DishImages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestaurantImages",
                table: "RestaurantProfile",
                newName: "RestaurantImage");

            migrationBuilder.RenameColumn(
                name: "DishImages",
                table: "Dish",
                newName: "DishImage");
        }
    }
}
