using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VendorService.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryCharge = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorStock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    HandInStocks = table.Column<int>(type: "int", nullable: false),
                    ReplinshmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorStock_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "Id", "DeliveryCharge", "Name", "Rating" },
                values: new object[] { 201, 45, "DelhiMotoShop", 5 });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "Id", "DeliveryCharge", "Name", "Rating" },
                values: new object[] { 202, 50, "HydMotoShop", 4 });

            migrationBuilder.InsertData(
                table: "VendorStock",
                columns: new[] { "Id", "HandInStocks", "ProductId", "ReplinshmentDate", "VendorId" },
                values: new object[,]
                {
                    { 1, 24, 1, new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 201 },
                    { 3, 24, 4, new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 201 },
                    { 2, 24, 3, new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 202 },
                    { 4, 24, 5, new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 202 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendorStock_VendorId",
                table: "VendorStock",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendorStock");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
