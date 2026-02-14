using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class t : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartitem_Cart_Cartid",
                table: "Cartitem");

            migrationBuilder.RenameColumn(
                name: "Cartid",
                table: "Cartitem",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Cartitem_Cartid",
                table: "Cartitem",
                newName: "IX_Cartitem_CartId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "Cartitem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartitem_Cart_CartId",
                table: "Cartitem",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartitem_Cart_CartId",
                table: "Cartitem");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Cartitem",
                newName: "Cartid");

            migrationBuilder.RenameIndex(
                name: "IX_Cartitem_CartId",
                table: "Cartitem",
                newName: "IX_Cartitem_Cartid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Cartid",
                table: "Cartitem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cartitem_Cart_Cartid",
                table: "Cartitem",
                column: "Cartid",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
