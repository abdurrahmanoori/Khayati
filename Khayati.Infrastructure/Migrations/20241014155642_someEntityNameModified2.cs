using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class someEntityNameModified2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmbellishmentTypeName",
                table: "EmbellishmentTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EmbellishmentTypeDiscription",
                table: "EmbellishmentTypes",
                newName: "Discription");

            migrationBuilder.RenameIndex(
                name: "IX_EmbellishmentTypes_EmbellishmentTypeName",
                table: "EmbellishmentTypes",
                newName: "IX_EmbellishmentTypes_Name");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EmbellishmentTypes",
                newName: "EmbellishmentTypeName");

            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "EmbellishmentTypes",
                newName: "EmbellishmentTypeDiscription");

            migrationBuilder.RenameIndex(
                name: "IX_EmbellishmentTypes_Name",
                table: "EmbellishmentTypes",
                newName: "IX_EmbellishmentTypes_EmbellishmentTypeName");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8474));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8475));
        }
    }
}
