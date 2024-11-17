using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class AutiabelEnti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "DateTaken",
                table: "Measurements",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Measurements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Measurements",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Measurements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Measurements",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Measurements",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Measurements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "SortOrder",
                table: "EmbellishmentTypes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAcitve",
                table: "Embellishment",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Customers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Customers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Customers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 20, 22, 30, 700, DateTimeKind.Local).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 20, 22, 30, 700, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 20, 22, 30, 700, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 20, 22, 30, 700, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.CreateIndex(
                name: "IX_EmbellishmentTypes_EmbellishmentTypeName",
                table: "EmbellishmentTypes",
                column: "EmbellishmentTypeName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmbellishmentTypes_EmbellishmentTypeName",
                table: "EmbellishmentTypes");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "EmbellishmentTypes");

            migrationBuilder.DropColumn(
                name: "IsAcitve",
                table: "Embellishment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Measurements",
                newName: "DateTaken");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Measurements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateTaken" },
                values: new object[] { new DateTime(2024, 10, 8, 6, 20, 10, 895, DateTimeKind.Local).AddTicks(8807), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateTaken" },
                values: new object[] { new DateTime(2024, 10, 8, 6, 20, 10, 895, DateTimeKind.Local).AddTicks(8821), new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateTaken" },
                values: new object[] { new DateTime(2024, 10, 8, 6, 20, 10, 895, DateTimeKind.Local).AddTicks(8822), new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateTaken" },
                values: new object[] { new DateTime(2024, 10, 8, 6, 20, 10, 895, DateTimeKind.Local).AddTicks(8824), new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
