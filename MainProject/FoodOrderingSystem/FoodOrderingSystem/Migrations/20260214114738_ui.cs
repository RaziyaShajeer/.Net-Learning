using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class ui : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartitem_Cart_CartId",
                table: "Cartitem");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Cartitem",
                newName: "cartId");

            migrationBuilder.RenameIndex(
                name: "IX_Cartitem_CartId",
                table: "Cartitem",
                newName: "IX_Cartitem_cartId");

            migrationBuilder.AlterColumn<Guid>(
                name: "cartId",
                table: "Cartitem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cartitem_Cart_cartId",
                table: "Cartitem",
                column: "cartId",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartitem_Cart_cartId",
                table: "Cartitem");

            migrationBuilder.RenameColumn(
                name: "cartId",
                table: "Cartitem",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Cartitem_cartId",
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
    }
}
