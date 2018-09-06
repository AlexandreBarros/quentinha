using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegalUserReview",
                columns: table => new
                {
                    LegalUserReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopLegalUserId = table.Column<Guid>(nullable: true),
                    UserIndividualUserId = table.Column<Guid>(nullable: true),
                    Review = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(maxLength: 140, nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalUserReview", x => x.LegalUserReviewId);
                    table.ForeignKey(
                        name: "FK_LegalUserReview_LegalUser_ShopLegalUserId",
                        column: x => x.ShopLegalUserId,
                        principalTable: "LegalUser",
                        principalColumn: "LegalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LegalUserReview_IndividualUser_UserIndividualUserId",
                        column: x => x.UserIndividualUserId,
                        principalTable: "IndividualUser",
                        principalColumn: "IndividualUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalUserReview_ShopLegalUserId",
                table: "LegalUserReview",
                column: "ShopLegalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalUserReview_UserIndividualUserId",
                table: "LegalUserReview",
                column: "UserIndividualUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalUserReview");
        }
    }
}
