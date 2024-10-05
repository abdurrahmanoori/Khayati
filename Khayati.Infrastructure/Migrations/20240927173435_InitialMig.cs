using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class InitialMig : Migration
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
                    CustomerAddress = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    NationalID = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerSince = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "EmbellishmentTypes",
                columns: table => new
                {
                    EmbellishmentTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmbellishmentTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    EmbellishmentTypeDiscription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmbellishmentTypes", x => x.EmbellishmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Measurementid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTaken = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    ArmLength = table.Column<double>(type: "REAL", nullable: false),
                    Sleeve = table.Column<double>(type: "REAL", nullable: false),
                    ShoulderWidth = table.Column<double>(type: "REAL", nullable: false),
                    Neck = table.Column<double>(type: "REAL", nullable: false),
                    Chest = table.Column<double>(type: "REAL", nullable: false),
                    Waist = table.Column<double>(type: "REAL", nullable: false),
                    trousers = table.Column<double>(type: "REAL", nullable: false),
                    Leg = table.Column<double>(type: "REAL", nullable: false),
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
                    TotalCost = table.Column<decimal>(type: "TEXT", nullable: false),
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
                    EmbellishmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmbellishmentName = table.Column<string>(type: "TEXT", nullable: false),
                    EmbellishmentDiscription = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<int>(type: "INTEGER", nullable: true),
                    EmbellishmentTypeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embellishment", x => x.EmbellishmentId);
                    table.ForeignKey(
                        name: "FK_Embellishment_EmbellishmentTypes_EmbellishmentTypeId",
                        column: x => x.EmbellishmentTypeId,
                        principalTable: "EmbellishmentTypes",
                        principalColumn: "EmbellishmentTypeId");
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
                    EmbellishmentId = table.Column<int>(type: "INTEGER", nullable: true),
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
                        name: "FK_OrderDesigns_Embellishment_EmbellishmentId",
                        column: x => x.EmbellishmentId,
                        principalTable: "Embellishment",
                        principalColumn: "EmbellishmentId");
                    table.ForeignKey(
                        name: "FK_OrderDesigns_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType", "DateOfBirth", "EmailAddress", "NationalID", "PhoneNumber" },
                values: new object[] { 1, "123 Main St, Springfield", "John Doe", new DateTime(2010, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regular", new DateTime(1985, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@example.com", "1234567890", "123-456-7890" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType", "DateOfBirth", "EmailAddress", "NationalID", "PhoneNumber" },
                values: new object[] { 2, "456 Elm St, Springfield", "Jane Smith", new DateTime(2015, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIP", new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "janesmith@example.com", "0987654321", "987-654-3210" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType", "DateOfBirth", "EmailAddress", "NationalID", "PhoneNumber" },
                values: new object[] { 3, "789 Oak St, Metropolis", "Robert Brown", new DateTime(2008, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate", new DateTime(1975, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "robertbrown@example.com", "4567890123", "555-123-4567" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType", "DateOfBirth", "EmailAddress", "NationalID", "PhoneNumber" },
                values: new object[] { 4, "321 Pine St, Gotham", "Emily Davis", new DateTime(2017, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regular", new DateTime(1992, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "emilydavis@example.com", "3216549870", "321-654-9870" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType", "DateOfBirth", "EmailAddress", "NationalID", "PhoneNumber" },
                values: new object[] { 5, "654 Maple St, Star City", "Michael Johnson", new DateTime(2005, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIP", new DateTime(1980, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "michaeljohnson@example.com", "9876543210", "777-888-9999" });

            migrationBuilder.CreateIndex(
                name: "IX_Embellishment_EmbellishmentTypeId",
                table: "Embellishment",
                column: "EmbellishmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_CustomerId",
                table: "Measurements",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDesigns_CustomerId",
                table: "OrderDesigns",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDesigns_EmbellishmentId",
                table: "OrderDesigns",
                column: "EmbellishmentId");

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
