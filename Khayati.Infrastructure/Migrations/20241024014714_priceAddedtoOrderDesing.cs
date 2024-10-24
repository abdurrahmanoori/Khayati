using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class priceAddedtoOrderDesing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "Embellishment",
                newName: "Description");

            migrationBuilder.AddColumn<short>(
                name: "Price",
                table: "OrderDesigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 6, 17, 14, 248, DateTimeKind.Local).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 6, 17, 14, 248, DateTimeKind.Local).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 6, 17, 14, 248, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 24, 6, 17, 14, 248, DateTimeKind.Local).AddTicks(7069));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderDesigns");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Embellishment",
                newName: "Discription");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 21, 11, 32, 727, DateTimeKind.Local).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 21, 11, 32, 727, DateTimeKind.Local).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 21, 11, 32, 727, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 21, 11, 32, 727, DateTimeKind.Local).AddTicks(9998));
        }
    }
}
