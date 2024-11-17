using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class SeedMeasurmentSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Measurementid", "ArmLength", "Chest", "CustomerId", "DateCreated", "DateTaken", "Height", "Leg", "Neck", "ShoulderWidth", "Sleeve", "Waist", "trousers" },
                values: new object[] { 1, 62.0, 100.0, 1, new DateTime(2024, 10, 8, 6, 20, 10, 895, DateTimeKind.Local).AddTicks(8807), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 175.5, 80.0, 38.0, 45.0, 60.0, 80.0, 0.0 });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Measurementid", "ArmLength", "Chest", "CustomerId", "DateCreated", "DateTaken", "Height", "Leg", "Neck", "ShoulderWidth", "Sleeve", "Waist", "trousers" },
                values: new object[] { 2, 63.0, 101.0, 2, new DateTime(2024, 10, 8, 6, 20, 10, 895, DateTimeKind.Local).AddTicks(8821), new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 176.0, 81.0, 39.0, 46.0, 61.0, 81.0, 0.0 });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Measurementid", "ArmLength", "Chest", "CustomerId", "DateCreated", "DateTaken", "Height", "Leg", "Neck", "ShoulderWidth", "Sleeve", "Waist", "trousers" },
                values: new object[] { 3, 62.5, 99.0, 3, new DateTime(2024, 10, 8, 6, 20, 10, 895, DateTimeKind.Local).AddTicks(8822), new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 175.5, 79.0, 38.5, 45.0, 60.5, 79.0, 0.0 });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Measurementid", "ArmLength", "Chest", "CustomerId", "DateCreated", "DateTaken", "Height", "Leg", "Neck", "ShoulderWidth", "Sleeve", "Waist", "trousers" },
                values: new object[] { 4, 64.0, 102.0, 4, new DateTime(2024, 10, 8, 6, 20, 10, 895, DateTimeKind.Local).AddTicks(8824), new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 177.0, 82.0, 40.0, 46.0, 62.0, 82.0, 0.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
