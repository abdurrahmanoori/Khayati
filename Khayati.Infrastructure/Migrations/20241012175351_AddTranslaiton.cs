using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class AddTranslaiton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    TranslationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityType = table.Column<string>(type: "TEXT", nullable: false),
                    EntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageCode = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyName = table.Column<string>(type: "TEXT", nullable: false),
                    TranslatedValue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.TranslationId);
                });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 12, 22, 23, 50, 995, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 12, 22, 23, 50, 995, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 12, 22, 23, 50, 995, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 12, 22, 23, 50, 995, DateTimeKind.Local).AddTicks(9496));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translations");

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
        }
    }
}
