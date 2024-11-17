using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class SomecolumnRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmbellishmentName",
                table: "Embellishment",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EmbellishmentDiscription",
                table: "Embellishment",
                newName: "Discription");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 7, 39, 8, 378, DateTimeKind.Local).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 7, 39, 8, 378, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 7, 39, 8, 378, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 7, 39, 8, 378, DateTimeKind.Local).AddTicks(3785));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Embellishment",
                newName: "EmbellishmentName");

            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "Embellishment",
                newName: "EmbellishmentDiscription");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 20, 26, 41, 690, DateTimeKind.Local).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 20, 26, 41, 690, DateTimeKind.Local).AddTicks(8512));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 20, 26, 41, 690, DateTimeKind.Local).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 20, 26, 41, 690, DateTimeKind.Local).AddTicks(8516));
        }
    }
}
