using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class seedEmb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmbellishmentTypes",
                columns: new[] { "EmbellishmentTypeId", "EmbellishmentTypeDiscription", "EmbellishmentTypeName" },
                values: new object[] { 1, "Various neck styles.", "Neck" });

            migrationBuilder.InsertData(
                table: "EmbellishmentTypes",
                columns: new[] { "EmbellishmentTypeId", "EmbellishmentTypeDiscription", "EmbellishmentTypeName" },
                values: new object[] { 2, "Different sleeve styles.", "Sleeve" });

            migrationBuilder.InsertData(
                table: "EmbellishmentTypes",
                columns: new[] { "EmbellishmentTypeId", "EmbellishmentTypeDiscription", "EmbellishmentTypeName" },
                values: new object[] { 3, "Different hem styles.", "Hem" });

            migrationBuilder.InsertData(
                table: "EmbellishmentTypes",
                columns: new[] { "EmbellishmentTypeId", "EmbellishmentTypeDiscription", "EmbellishmentTypeName" },
                values: new object[] { 4, "Various pocket styles.", "Pocket" });

            migrationBuilder.InsertData(
                table: "EmbellishmentTypes",
                columns: new[] { "EmbellishmentTypeId", "EmbellishmentTypeDiscription", "EmbellishmentTypeName" },
                values: new object[] { 5, "Different embroidery styles.", "Embroidery" });

            migrationBuilder.InsertData(
                table: "Embellishment",
                columns: new[] { "EmbellishmentId", "Cost", "EmbellishmentDiscription", "EmbellishmentName", "EmbellishmentTypeId" },
                values: new object[] { 1, 20, "A circular neck style.", "Circle Neck", 1 });

            migrationBuilder.InsertData(
                table: "Embellishment",
                columns: new[] { "EmbellishmentId", "Cost", "EmbellishmentDiscription", "EmbellishmentName", "EmbellishmentTypeId" },
                values: new object[] { 2, 25, "A V-shaped neck style.", "V-Neck", 1 });

            migrationBuilder.InsertData(
                table: "Embellishment",
                columns: new[] { "EmbellishmentId", "Cost", "EmbellishmentDiscription", "EmbellishmentName", "EmbellishmentTypeId" },
                values: new object[] { 3, 15, "A short sleeve style.", "Short Sleeve", 2 });

            migrationBuilder.InsertData(
                table: "Embellishment",
                columns: new[] { "EmbellishmentId", "Cost", "EmbellishmentDiscription", "EmbellishmentName", "EmbellishmentTypeId" },
                values: new object[] { 4, 30, "A long sleeve style.", "Long Sleeve", 2 });

            migrationBuilder.InsertData(
                table: "Embellishment",
                columns: new[] { "EmbellishmentId", "Cost", "EmbellishmentDiscription", "EmbellishmentName", "EmbellishmentTypeId" },
                values: new object[] { 5, 10, "A frayed hem style.", "Frayed Hem", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Embellishment",
                keyColumn: "EmbellishmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Embellishment",
                keyColumn: "EmbellishmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Embellishment",
                keyColumn: "EmbellishmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Embellishment",
                keyColumn: "EmbellishmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Embellishment",
                keyColumn: "EmbellishmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmbellishmentTypes",
                keyColumn: "EmbellishmentTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmbellishmentTypes",
                keyColumn: "EmbellishmentTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmbellishmentTypes",
                keyColumn: "EmbellishmentTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmbellishmentTypes",
                keyColumn: "EmbellishmentTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmbellishmentTypes",
                keyColumn: "EmbellishmentTypeId",
                keyValue: 3);
        }
    }
}
