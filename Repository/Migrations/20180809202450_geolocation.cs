using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class geolocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "Address",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "Address",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Address");
        }
    }
}
