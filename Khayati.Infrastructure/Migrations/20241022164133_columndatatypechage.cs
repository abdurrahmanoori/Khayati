using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class columndatatypechage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 6, 51, 14, 853, DateTimeKind.Local).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 6, 51, 14, 853, DateTimeKind.Local).AddTicks(983));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 6, 51, 14, 853, DateTimeKind.Local).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 6, 51, 14, 853, DateTimeKind.Local).AddTicks(986));
        }
    }
}
