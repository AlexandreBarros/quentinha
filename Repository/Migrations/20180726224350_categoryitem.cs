using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class categoryitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItem_Category_CategoryId",
                table: "CategoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItem_Item_ItemId",
                table: "CategoryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryItem",
                table: "CategoryItem");

            migrationBuilder.DropIndex(
                name: "IX_CategoryItem_CategoryId",
                table: "CategoryItem");

            migrationBuilder.DropColumn(
                name: "CategoryItemId",
                table: "CategoryItem");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CategoryItem");

            migrationBuilder.DropColumn(
                name: "DetachmentDate",
                table: "CategoryItem");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "CategoryItem");

            migrationBuilder.DropColumn(
                name: "ShowOnHomePage",
                table: "CategoryItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "CategoryItem",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "CategoryItem",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryItem",
                table: "CategoryItem",
                columns: new[] { "CategoryId", "ItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItem_Category_CategoryId",
                table: "CategoryItem",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItem_Item_ItemId",
                table: "CategoryItem",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItem_Category_CategoryId",
                table: "CategoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItem_Item_ItemId",
                table: "CategoryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryItem",
                table: "CategoryItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "CategoryItem",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "CategoryItem",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryItemId",
                table: "CategoryItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CategoryItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DetachmentDate",
                table: "CategoryItem",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "CategoryItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnHomePage",
                table: "CategoryItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryItem",
                table: "CategoryItem",
                column: "CategoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_CategoryId",
                table: "CategoryItem",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItem_Category_CategoryId",
                table: "CategoryItem",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItem_Item_ItemId",
                table: "CategoryItem",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
