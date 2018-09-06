using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class restaurantclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResturantClasses",
                columns: table => new
                {
                    RestaurantClassesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResturantClasses", x => x.RestaurantClassesId);
                });

            migrationBuilder.CreateTable(
                name: "LegalUserRestaurantClasses",
                columns: table => new
                {
                    LegalUserRestaurantClassesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalUserId = table.Column<Guid>(nullable: true),
                    ClassRestaurantClassesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalUserRestaurantClasses", x => x.LegalUserRestaurantClassesId);
                    table.ForeignKey(
                        name: "FK_LegalUserRestaurantClasses_ResturantClasses_ClassRestaurantClassesId",
                        column: x => x.ClassRestaurantClassesId,
                        principalTable: "ResturantClasses",
                        principalColumn: "RestaurantClassesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LegalUserRestaurantClasses_LegalUser_LegalUserId",
                        column: x => x.LegalUserId,
                        principalTable: "LegalUser",
                        principalColumn: "LegalUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalUserRestaurantClasses_ClassRestaurantClassesId",
                table: "LegalUserRestaurantClasses",
                column: "ClassRestaurantClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalUserRestaurantClasses_LegalUserId",
                table: "LegalUserRestaurantClasses",
                column: "LegalUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalUserRestaurantClasses");

            migrationBuilder.DropTable(
                name: "ResturantClasses");
        }
    }
}
