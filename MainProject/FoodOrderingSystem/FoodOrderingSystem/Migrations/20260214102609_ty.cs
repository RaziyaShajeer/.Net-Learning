using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class ty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "UserDTO");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Cart");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "UserDTO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cartitem_Cartid",
                table: "Cartitem",
                column: "Cartid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartitem_Cart_Cartid",
                table: "Cartitem",
                column: "Cartid",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartitem_Cart_Cartid",
                table: "Cartitem");

            migrationBuilder.DropIndex(
                name: "IX_Cartitem_Cartid",
                table: "Cartitem");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "UserDTO");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "UserDTO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Cart",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cart",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
