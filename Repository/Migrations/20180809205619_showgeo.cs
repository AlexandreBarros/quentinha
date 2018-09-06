using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class showgeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowGeoPosition",
                table: "LegalUser",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowGeoPosition",
                table: "LegalUser");
        }
    }
}
