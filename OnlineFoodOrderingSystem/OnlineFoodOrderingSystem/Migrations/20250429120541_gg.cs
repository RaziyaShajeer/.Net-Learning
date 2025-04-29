using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineFoodOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class gg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestauratType = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CeatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_restaurants_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dishes",
                columns: table => new
                {
                    DishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DishImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    category = table.Column<int>(type: "int", nullable: false),
                    Availablity = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dishes", x => x.DishId);
                    table.ForeignKey(
                        name: "FK_dishes_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    RestaurantId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RestaurantAdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_restaurants_RestaurantId1",
                        column: x => x.RestaurantId1,
                        principalTable: "restaurants",
                        principalColumn: "RestaurantId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_dishes_RestaurantId",
                table: "dishes",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_LocationId",
                table: "restaurants",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationId",
                table: "Users",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RestaurantId",
                table: "Users",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RestaurantId1",
                table: "Users",
                column: "RestaurantId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dishes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "restaurants");

            migrationBuilder.DropTable(
                name: "locations");
        }
    }
}
