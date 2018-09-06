using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class list : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalUser_City_CityId",
                table: "LegalUser");

            migrationBuilder.DropIndex(
                name: "IX_LegalUser_CityId",
                table: "LegalUser");

            migrationBuilder.DropColumn(
                name: "AddOn",
                table: "LegalUser");

            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "LegalUser");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "LegalUser");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "LegalUser");

            migrationBuilder.DropColumn(
                name: "NeighborHood",
                table: "LegalUser");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "LegalUser");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "LegalUser");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "LegalUser");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "LegalUser");

            migrationBuilder.AddColumn<Guid>(
                name: "LegalUserId",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LegalUserId",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_LegalUserId",
                table: "Contact",
                column: "LegalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_LegalUserId",
                table: "Address",
                column: "LegalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_LegalUser_LegalUserId",
                table: "Address",
                column: "LegalUserId",
                principalTable: "LegalUser",
                principalColumn: "LegalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_LegalUser_LegalUserId",
                table: "Contact",
                column: "LegalUserId",
                principalTable: "LegalUser",
                principalColumn: "LegalUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_LegalUser_LegalUserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_LegalUser_LegalUserId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_LegalUserId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Address_LegalUserId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "LegalUserId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "LegalUserId",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "AddOn",
                table: "LegalUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "LegalUser",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "LegalUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "LegalUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeighborHood",
                table: "LegalUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "LegalUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "LegalUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "LegalUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
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
    }
}
