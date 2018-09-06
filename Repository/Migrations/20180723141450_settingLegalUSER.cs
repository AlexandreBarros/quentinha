using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class settingLegalUSER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessHours");

            migrationBuilder.CreateTable(
                name: "LegalUserSettings",
                columns: table => new
                {
                    LegalUserSettingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalUserId = table.Column<Guid>(nullable: true),
                    DeliveryCoust = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    IsOpen = table.Column<bool>(nullable: false),
                    MondayIsWorkDay = table.Column<bool>(nullable: false),
                    MondayStartHour = table.Column<string>(maxLength: 5, nullable: true),
                    MondayEndHour = table.Column<string>(maxLength: 5, nullable: true),
                    TuesdayIsWorkDay = table.Column<bool>(nullable: false),
                    TuesdayStartHour = table.Column<string>(maxLength: 5, nullable: true),
                    TuesdayEndHour = table.Column<string>(maxLength: 5, nullable: true),
                    WednesdayIsWorkDay = table.Column<bool>(nullable: false),
                    WednesdayStartHour = table.Column<string>(maxLength: 5, nullable: true),
                    WednesdayEndHour = table.Column<string>(maxLength: 5, nullable: true),
                    ThursdayIsWorkDay = table.Column<bool>(nullable: false),
                    ThursdayStartHour = table.Column<string>(maxLength: 5, nullable: true),
                    ThursdayEndHour = table.Column<string>(maxLength: 5, nullable: true),
                    FridayIsWorkDay = table.Column<bool>(nullable: false),
                    FridayStartHour = table.Column<string>(maxLength: 5, nullable: true),
                    FridayEndHour = table.Column<string>(maxLength: 5, nullable: true),
                    SaturdayIsWorkDay = table.Column<bool>(nullable: false),
                    SaturdayStartHour = table.Column<string>(maxLength: 5, nullable: true),
                    SaturdayEndHour = table.Column<string>(maxLength: 5, nullable: true),
                    SundayIsWorkDay = table.Column<bool>(nullable: false),
                    SundayStartHour = table.Column<string>(maxLength: 5, nullable: true),
                    SundayEndHour = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalUserSettings", x => x.LegalUserSettingsId);
                    table.ForeignKey(
                        name: "FK_LegalUserSettings_LegalUser_LegalUserId",
                        column: x => x.LegalUserId,
                        principalTable: "LegalUser",
                        principalColumn: "LegalUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalUserSettings_LegalUserId",
                table: "LegalUserSettings",
                column: "LegalUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalUserSettings");

            migrationBuilder.CreateTable(
                name: "BusinessHours",
                columns: table => new
                {
                    BusinessHoursId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalUserId = table.Column<Guid>(nullable: true),
                    TimeTableDescription = table.Column<string>(nullable: true),
                    WorkDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessHours", x => x.BusinessHoursId);
                    table.ForeignKey(
                        name: "FK_BusinessHours_LegalUser_LegalUserId",
                        column: x => x.LegalUserId,
                        principalTable: "LegalUser",
                        principalColumn: "LegalUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessHours_LegalUserId",
                table: "BusinessHours",
                column: "LegalUserId");
        }
    }
}
