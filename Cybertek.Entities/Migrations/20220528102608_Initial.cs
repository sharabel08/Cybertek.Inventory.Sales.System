using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cybertek.Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "master");

            migrationBuilder.EnsureSchema(
                name: "data");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "master",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "master",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Purchasing",
                schema: "data",
                columns: table => new
                {
                    PurchasingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchasing", x => x.PurchasingId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "master",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Purchasing",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "master");
        }
    }
}
