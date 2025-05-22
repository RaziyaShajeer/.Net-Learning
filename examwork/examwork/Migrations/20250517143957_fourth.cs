using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace examwork.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "students");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "students");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
