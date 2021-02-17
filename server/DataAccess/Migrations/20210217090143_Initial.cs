using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    LastLoggedInDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProvinceOrState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<int>(type: "int", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmailSettings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseExpiresInXMonths = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSettings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductSupplier = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "License",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SiteID = table.Column<int>(type: "int", nullable: false),
                    AdminUserID = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.ID);
                    table.ForeignKey(
                        name: "FK_License_AdminUser_AdminUserID",
                        column: x => x.AdminUserID,
                        principalTable: "AdminUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_License_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_License_Sites_SiteID",
                        column: x => x.SiteID,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteID = table.Column<int>(type: "int", nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recipient_Sites_SiteID",
                        column: x => x.SiteID,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdminUser",
                columns: new[] { "ID", "Active", "EmailAddress", "FirstName", "LastLoggedInDateTime", "LastName", "Password" },
                values: new object[] { 1, true, "lana@devinspire.com", "Admin User", null, "Admin User", "Pass@123" });

            migrationBuilder.CreateIndex(
                name: "IX_License_AdminUserID",
                table: "License",
                column: "AdminUserID");

            migrationBuilder.CreateIndex(
                name: "IX_License_ProductID",
                table: "License",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_License_SiteID",
                table: "License",
                column: "SiteID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipient_SiteID",
                table: "Recipient",
                column: "SiteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "EmailSettings");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.DropTable(
                name: "AdminUser");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
