using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class locationid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyUser_Location",
                table: "MyUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK__MyUser__1788CC4C3F1B5C0A",
                table: "MyUser");

            migrationBuilder.DropIndex(
                name: "IX_MyUser_LocationId",
                table: "MyUser");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "MyUser");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "DishDTO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyUser",
                table: "MyUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MyUser",
                table: "MyUser");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "MyUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "DishDTO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK__MyUser__1788CC4C3F1B5C0A",
                table: "MyUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyUser_LocationId",
                table: "MyUser",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyUser_Location",
                table: "MyUser",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId");
        }
    }
}
