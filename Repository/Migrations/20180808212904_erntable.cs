using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class erntable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalUserRestaurantClasses_ResturantClasses_ClassRestaurantClassesId",
                table: "LegalUserRestaurantClasses");

            migrationBuilder.DropTable(
                name: "ResturantClasses");

            migrationBuilder.CreateTable(
                name: "RestaurantClasses",
                columns: table => new
                {
                    RestaurantClassesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantClasses", x => x.RestaurantClassesId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LegalUserRestaurantClasses_RestaurantClasses_ClassRestaurantClassesId",
                table: "LegalUserRestaurantClasses",
                column: "ClassRestaurantClassesId",
                principalTable: "RestaurantClasses",
                principalColumn: "RestaurantClassesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalUserRestaurantClasses_RestaurantClasses_ClassRestaurantClassesId",
                table: "LegalUserRestaurantClasses");

            migrationBuilder.DropTable(
                name: "RestaurantClasses");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LegalUserRestaurantClasses_ResturantClasses_ClassRestaurantClassesId",
                table: "LegalUserRestaurantClasses",
                column: "ClassRestaurantClassesId",
                principalTable: "ResturantClasses",
                principalColumn: "RestaurantClassesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
