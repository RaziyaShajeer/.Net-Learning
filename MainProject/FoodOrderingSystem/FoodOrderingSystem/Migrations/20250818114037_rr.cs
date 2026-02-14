using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class rr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_RestaurantProfile",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_MyUser_Location",
                table: "MyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantProfile_Location",
                table: "RestaurantProfile");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RestaurantProfile_TempId1",
                table: "RestaurantProfile");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RestaurantProfile_TempId2",
                table: "RestaurantProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MyUser__1788CC4C3F1B5C0A",
                table: "MyUser");

            migrationBuilder.DropIndex(
                name: "IX_MyUser_LocationId",
                table: "MyUser");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "UserDTO");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "RestaurantProfile");

            migrationBuilder.DropColumn(
                name: "TempId1",
                table: "RestaurantProfile");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "MyUser");

            migrationBuilder.RenameColumn(
                name: "TempId2",
                table: "RestaurantProfile",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "DishImages",
                table: "Dish",
                newName: "DishImage");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "UserDTO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RestaurantProfile",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "RestaurantProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "RestaurantProfile",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "RestaurantImages",
                table: "RestaurantProfile",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantName",
                table: "RestaurantProfile",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RestauratType",
                table: "RestaurantProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RestaurantProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "MyUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Dish",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantProfile",
                table: "RestaurantProfile",
                column: "RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyUser",
                table: "MyUser",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "DishDTO",
                columns: table => new
                {
                    DishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_RestaurantProfile",
                table: "Dish",
                column: "RestaurantId",
                principalTable: "RestaurantProfile",
                principalColumn: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_RestaurantProfile",
                table: "Dish");

            migrationBuilder.DropTable(
                name: "DishDTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantProfile",
                table: "RestaurantProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyUser",
                table: "MyUser");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "UserDTO");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RestaurantProfile");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "RestaurantProfile");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "RestaurantProfile");

            migrationBuilder.DropColumn(
                name: "RestaurantImages",
                table: "RestaurantProfile");

            migrationBuilder.DropColumn(
                name: "RestaurantName",
                table: "RestaurantProfile");

            migrationBuilder.DropColumn(
                name: "RestauratType",
                table: "RestaurantProfile");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RestaurantProfile");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "MyUser");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Dish");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "RestaurantProfile",
                newName: "TempId2");

            migrationBuilder.RenameColumn(
                name: "DishImage",
                table: "Dish",
                newName: "DishImages");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationID",
                table: "UserDTO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "RestaurantProfile",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TempId1",
                table: "RestaurantProfile",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "MyUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RestaurantProfile_TempId1",
                table: "RestaurantProfile",
                column: "TempId1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RestaurantProfile_TempId2",
                table: "RestaurantProfile",
                column: "TempId2");

            migrationBuilder.AddPrimaryKey(
                name: "PK__MyUser__1788CC4C3F1B5C0A",
                table: "MyUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_LocationId",
                table: "MyUser",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_RestaurantProfile",
                table: "Dish",
                column: "RestaurantId",
                principalTable: "RestaurantProfile",
                principalColumn: "TempId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MyUser_Location",
                table: "MyUser",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantProfile_Location",
                table: "RestaurantProfile",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId");
        }
    }
}
