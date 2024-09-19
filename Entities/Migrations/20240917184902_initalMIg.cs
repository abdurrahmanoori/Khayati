using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class initalMIg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "EmbellishmentTypes",
                columns: table => new
                {
                    EmbellishmentmentTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmbellishmentmentTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    EmbellishmentmentTypeDiscription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmbellishmentTypes", x => x.EmbellishmentmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Measurementid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    Chest = table.Column<double>(type: "REAL", nullable: false),
                    Waist = table.Column<double>(type: "REAL", nullable: false),
                    Hip = table.Column<double>(type: "REAL", nullable: false),
                    ShoulderWidth = table.Column<double>(type: "REAL", nullable: false),
                    ArmLength = table.Column<double>(type: "REAL", nullable: false),
                    Inseam = table.Column<double>(type: "REAL", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Measurementid);
                    table.ForeignKey(
                        name: "FK_Measurements_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpectedCompletionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Embellishment",
                columns: table => new
                {
                    EmbellishmentmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmbellishmentmentName = table.Column<string>(type: "TEXT", nullable: false),
                    EmbellishmentmentDiscription = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<int>(type: "INTEGER", nullable: true),
                    EmbellishmentmentTypeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embellishment", x => x.EmbellishmentmentId);
                    table.ForeignKey(
                        name: "FK_Embellishment_EmbellishmentTypes_EmbellishmentmentTypeId",
                        column: x => x.EmbellishmentmentTypeId,
                        principalTable: "EmbellishmentTypes",
                        principalColumn: "EmbellishmentmentTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true),
                    PaymentStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "OrderDesigns",
                columns: table => new
                {
                    DesignId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    MeasurementId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmbellishmentmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDesigns", x => x.DesignId);
                    table.ForeignKey(
                        name: "FK_OrderDesigns_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDesigns_Embellishment_EmbellishmentmentId",
                        column: x => x.EmbellishmentmentId,
                        principalTable: "Embellishment",
                        principalColumn: "EmbellishmentmentId");
                    table.ForeignKey(
                        name: "FK_OrderDesigns_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Embellishment_EmbellishmentmentTypeId",
                table: "Embellishment",
                column: "EmbellishmentmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_CustomerId",
                table: "Measurements",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDesigns_CustomerId",
                table: "OrderDesigns",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDesigns_EmbellishmentmentId",
                table: "OrderDesigns",
                column: "EmbellishmentmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDesigns_OrderId",
                table: "OrderDesigns",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "OrderDesigns");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Embellishment");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "EmbellishmentTypes");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
