using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class FabricAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "FabricId",
                table: "OrderDesigns",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FabricId",
                table: "Measurements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fabrics",
                columns: table => new
                {
                    FabricId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FabricType = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Pattern = table.Column<string>(type: "TEXT", nullable: false),
                    Thickness = table.Column<short>(type: "INTEGER", nullable: false),
                    Durability = table.Column<string>(type: "TEXT", nullable: false),
                    CostPerMeter = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrics", x => x.FabricId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDesigns_FabricId",
                table: "OrderDesigns",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_FabricId",
                table: "Measurements",
                column: "FabricId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Fabrics_FabricId",
                table: "Measurements",
                column: "FabricId",
                principalTable: "Fabrics",
                principalColumn: "FabricId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDesigns_Fabrics_FabricId",
                table: "OrderDesigns",
                column: "FabricId",
                principalTable: "Fabrics",
                principalColumn: "FabricId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Fabrics_FabricId",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDesigns_Fabrics_FabricId",
                table: "OrderDesigns");

            migrationBuilder.DropTable(
                name: "Fabrics");

            migrationBuilder.DropIndex(
                name: "IX_OrderDesigns_FabricId",
                table: "OrderDesigns");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_FabricId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "FabricId",
                table: "OrderDesigns");

            migrationBuilder.DropColumn(
                name: "FabricId",
                table: "Measurements");

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Measurementid", "ArmLength", "Chest", "Cost", "CreatedAt", "CreatedBy", "CustomerId", "DeletedAt", "DeletedBy", "Height", "IsDeleted", "Leg", "Neck", "ShoulderWidth", "Sleeve", "UpdatedAt", "UpdatedBy", "Waist", "trousers" },
                values: new object[] { 1, 62.0, 100.0, null, new DateTime(2024, 10, 29, 6, 55, 21, 68, DateTimeKind.Local).AddTicks(5891), null, 1, null, null, 175.5, false, 80.0, 38.0, 45.0, 60.0, null, null, 80.0, 0.0 });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Measurementid", "ArmLength", "Chest", "Cost", "CreatedAt", "CreatedBy", "CustomerId", "DeletedAt", "DeletedBy", "Height", "IsDeleted", "Leg", "Neck", "ShoulderWidth", "Sleeve", "UpdatedAt", "UpdatedBy", "Waist", "trousers" },
                values: new object[] { 2, 63.0, 101.0, null, new DateTime(2024, 10, 29, 6, 55, 21, 68, DateTimeKind.Local).AddTicks(5902), null, 2, null, null, 176.0, false, 81.0, 39.0, 46.0, 61.0, null, null, 81.0, 0.0 });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Measurementid", "ArmLength", "Chest", "Cost", "CreatedAt", "CreatedBy", "CustomerId", "DeletedAt", "DeletedBy", "Height", "IsDeleted", "Leg", "Neck", "ShoulderWidth", "Sleeve", "UpdatedAt", "UpdatedBy", "Waist", "trousers" },
                values: new object[] { 3, 62.5, 99.0, null, new DateTime(2024, 10, 29, 6, 55, 21, 68, DateTimeKind.Local).AddTicks(5903), null, 3, null, null, 175.5, false, 79.0, 38.5, 45.0, 60.5, null, null, 79.0, 0.0 });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Measurementid", "ArmLength", "Chest", "Cost", "CreatedAt", "CreatedBy", "CustomerId", "DeletedAt", "DeletedBy", "Height", "IsDeleted", "Leg", "Neck", "ShoulderWidth", "Sleeve", "UpdatedAt", "UpdatedBy", "Waist", "trousers" },
                values: new object[] { 4, 64.0, 102.0, null, new DateTime(2024, 10, 29, 6, 55, 21, 68, DateTimeKind.Local).AddTicks(5905), null, 4, null, null, 177.0, false, 82.0, 40.0, 46.0, 62.0, null, null, 82.0, 0.0 });
        }
    }
}
