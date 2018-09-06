using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class city : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "LegalUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalUser_CityId",
                table: "LegalUser",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalUser_City_CityId",
                table: "LegalUser",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalUser_City_CityId",
                table: "LegalUser");

            migrationBuilder.DropIndex(
                name: "IX_LegalUser_CityId",
                table: "LegalUser");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "LegalUser");
        }
    }
}
