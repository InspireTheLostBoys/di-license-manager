using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_License_Sites_SiteID",
                table: "License");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_Sites_SiteID",
                table: "Recipient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sites",
                table: "Sites");

            migrationBuilder.RenameTable(
                name: "Sites",
                newName: "Site");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Site",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Site",
                newName: "SiteName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Site",
                table: "Site",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Site_CustomerID",
                table: "Site",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_License_Site_SiteID",
                table: "License",
                column: "SiteID",
                principalTable: "Site",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_Site_SiteID",
                table: "Recipient",
                column: "SiteID",
                principalTable: "Site",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_Customer_CustomerID",
                table: "Site",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_License_Site_SiteID",
                table: "License");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipient_Site_SiteID",
                table: "Recipient");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_Customer_CustomerID",
                table: "Site");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Site",
                table: "Site");

            migrationBuilder.DropIndex(
                name: "IX_Site_CustomerID",
                table: "Site");

            migrationBuilder.RenameTable(
                name: "Site",
                newName: "Sites");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Sites",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SiteName",
                table: "Sites",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sites",
                table: "Sites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_License_Sites_SiteID",
                table: "License",
                column: "SiteID",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipient_Sites_SiteID",
                table: "Recipient",
                column: "SiteID",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
