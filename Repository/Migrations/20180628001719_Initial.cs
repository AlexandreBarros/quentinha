using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cnpj = table.Column<string>(maxLength: 25, nullable: true),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Site = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DetachmentDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "IndividualUser",
                columns: table => new
                {
                    IndividualUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 1024, nullable: false),
                    UserName = table.Column<string>(maxLength: 128, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 128, nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DetachmentDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualUser", x => x.IndividualUserId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    PricePromo = table.Column<decimal>(type: "decimal(9,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "LegalUser",
                columns: table => new
                {
                    LegalUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalName = table.Column<string>(maxLength: 150, nullable: false),
                    NormalizedLegalName = table.Column<string>(maxLength: 150, nullable: false),
                    ExhibitionName = table.Column<string>(maxLength: 150, nullable: false),
                    NormalizedExhibitionName = table.Column<string>(maxLength: 150, nullable: false),
                    UrlData = table.Column<string>(nullable: false),
                    CNPJ = table.Column<string>(maxLength: 20, nullable: false),
                    InscEst = table.Column<string>(maxLength: 30, nullable: true),
                    InscMun = table.Column<string>(maxLength: 30, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    NeighborHood = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    AddOn = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DetachmentDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalUser", x => x.LegalUserId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    OrderStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    EnumIdentifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Initials = table.Column<string>(maxLength: 5, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 20, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DetachmentDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    IndividualUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contact_IndividualUser_IndividualUserId",
                        column: x => x.IndividualUserId,
                        principalTable: "IndividualUser",
                        principalColumn: "IndividualUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIndividualUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_IndividualUser_UserIndividualUserId",
                        column: x => x.UserIndividualUserId,
                        principalTable: "IndividualUser",
                        principalColumn: "IndividualUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalUserId = table.Column<Guid>(nullable: true),
                    Holder = table.Column<string>(maxLength: 50, nullable: false),
                    BankId = table.Column<int>(nullable: true),
                    Agency = table.Column<string>(maxLength: 10, nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Digit = table.Column<string>(maxLength: 3, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DetachmentDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.BankAccountId);
                    table.ForeignKey(
                        name: "FK_BankAccount_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankAccount_LegalUser_LegalUserId",
                        column: x => x.LegalUserId,
                        principalTable: "LegalUser",
                        principalColumn: "LegalUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessHours",
                columns: table => new
                {
                    BusinessHoursId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalUserId = table.Column<Guid>(nullable: true),
                    WorkDay = table.Column<int>(nullable: false),
                    TimeTableDescription = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentCategoryId = table.Column<Guid>(nullable: true),
                    LegalUserId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UrlCarteLogo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DetachmentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_LegalUser_LegalUserId",
                        column: x => x.LegalUserId,
                        principalTable: "LegalUser",
                        principalColumn: "LegalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserIndividualUserId = table.Column<Guid>(nullable: true),
                    LegalUserId = table.Column<Guid>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_LegalUser_LegalUserId",
                        column: x => x.LegalUserId,
                        principalTable: "LegalUser",
                        principalColumn: "LegalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_IndividualUser_UserIndividualUserId",
                        column: x => x.UserIndividualUserId,
                        principalTable: "IndividualUser",
                        principalColumn: "IndividualUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Promo",
                columns: table => new
                {
                    PromoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalUserId = table.Column<Guid>(nullable: true),
                    Img = table.Column<string>(maxLength: 4000, nullable: false),
                    FirstLayerFrase = table.Column<string>(maxLength: 100, nullable: false),
                    SecondLayerFrase = table.Column<string>(maxLength: 100, nullable: false),
                    ThirdLayerFrase = table.Column<string>(maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DetachmentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promo", x => x.PromoId);
                    table.ForeignKey(
                        name: "FK_Promo_LegalUser_LegalUserId",
                        column: x => x.LegalUserId,
                        principalTable: "LegalUser",
                        principalColumn: "LegalUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(nullable: true),
                    UserIndividualUserId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DetachmentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_IndividualUser_UserIndividualUserId",
                        column: x => x.UserIndividualUserId,
                        principalTable: "IndividualUser",
                        principalColumn: "IndividualUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    StateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryItem",
                columns: table => new
                {
                    CategoryItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(nullable: true),
                    ItemId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DetachmentDate = table.Column<DateTime>(nullable: true),
                    ShowOnHomePage = table.Column<bool>(nullable: false),
                    Enable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItem", x => x.CategoryItemId);
                    table.ForeignKey(
                        name: "FK_CategoryItem_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalUserId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    CustomerIndividualUserId = table.Column<Guid>(nullable: true),
                    StatusOrderStatusId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DeliveredDate = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_IndividualUser_CustomerIndividualUserId",
                        column: x => x.CustomerIndividualUserId,
                        principalTable: "IndividualUser",
                        principalColumn: "IndividualUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_LegalUser_LegalUserId",
                        column: x => x.LegalUserId,
                        principalTable: "LegalUser",
                        principalColumn: "LegalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_StatusOrderStatusId",
                        column: x => x.StatusOrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "OrderStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true),
                    NeighborHood = table.Column<string>(maxLength: 100, nullable: false),
                    Street = table.Column<string>(maxLength: 100, nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: true),
                    AddOn = table.Column<string>(maxLength: 10, nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DetachmentDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    IndividualUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_IndividualUser_IndividualUserId",
                        column: x => x.IndividualUserId,
                        principalTable: "IndividualUser",
                        principalColumn: "IndividualUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_IndividualUserId",
                table: "Address",
                column: "IndividualUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_BankId",
                table: "BankAccount",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_LegalUserId",
                table: "BankAccount",
                column: "LegalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessHours_LegalUserId",
                table: "BusinessHours",
                column: "LegalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_LegalUserId",
                table: "Category",
                column: "LegalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_CategoryId",
                table: "CategoryItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_ItemId",
                table: "CategoryItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_IndividualUserId",
                table: "Contact",
                column: "IndividualUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserIndividualUserId",
                table: "Customer",
                column: "UserIndividualUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LegalUserId",
                table: "Employee",
                column: "LegalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserIndividualUserId",
                table: "Employee",
                column: "UserIndividualUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerIndividualUserId",
                table: "Order",
                column: "CustomerIndividualUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeId",
                table: "Order",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_LegalUserId",
                table: "Order",
                column: "LegalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StatusOrderStatusId",
                table: "Order",
                column: "StatusOrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Promo_LegalUserId",
                table: "Promo",
                column: "LegalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserIndividualUserId",
                table: "UserRole",
                column: "UserIndividualUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "BusinessHours");

            migrationBuilder.DropTable(
                name: "CategoryItem");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Promo");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "LegalUser");

            migrationBuilder.DropTable(
                name: "IndividualUser");
        }
    }
}
