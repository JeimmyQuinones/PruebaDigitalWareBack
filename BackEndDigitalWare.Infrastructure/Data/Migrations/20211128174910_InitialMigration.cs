using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndDigitalWare.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DW");

            migrationBuilder.CreateTable(
                name: "IdentificationType",
                schema: "DW",
                columns: table => new
                {
                    IdentificationTypeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Synonymous = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationType", x => x.IdentificationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Mark",
                schema: "DW",
                columns: table => new
                {
                    MarkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark", x => x.MarkId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "DW",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentificationTypeId = table.Column<short>(type: "smallint", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_IdentificationType_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalSchema: "DW",
                        principalTable: "IdentificationType",
                        principalColumn: "IdentificationTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "DW",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Mark_MarkId",
                        column: x => x.MarkId,
                        principalSchema: "DW",
                        principalTable: "Mark",
                        principalColumn: "MarkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                schema: "DW",
                columns: table => new
                {
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bill_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "DW",
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailBill",
                schema: "DW",
                columns: table => new
                {
                    DetailBillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailBill", x => x.DetailBillId);
                    table.ForeignKey(
                        name: "FK_DetailBill_Bill_BillId",
                        column: x => x.BillId,
                        principalSchema: "DW",
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailBill_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "DW",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_CustomerId",
                schema: "DW",
                table: "Bill",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdentificationTypeId",
                schema: "DW",
                table: "Customer",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailBill_BillId",
                schema: "DW",
                table: "DetailBill",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailBill_ProductId",
                schema: "DW",
                table: "DetailBill",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MarkId",
                schema: "DW",
                table: "Product",
                column: "MarkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailBill",
                schema: "DW");

            migrationBuilder.DropTable(
                name: "Bill",
                schema: "DW");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "DW");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "DW");

            migrationBuilder.DropTable(
                name: "Mark",
                schema: "DW");

            migrationBuilder.DropTable(
                name: "IdentificationType",
                schema: "DW");
        }
    }
}
