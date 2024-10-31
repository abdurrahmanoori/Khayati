using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class FabricSeederAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fabrics",
                columns: new[] { "FabricId", "Color", "CostPerMeter", "Durability", "FabricType", "Pattern", "Thickness" },
                values: new object[] { 1, "White", 25.5m, "High", "Cotton", "Plain", (short)5 });

            migrationBuilder.InsertData(
                table: "Fabrics",
                columns: new[] { "FabricId", "Color", "CostPerMeter", "Durability", "FabricType", "Pattern", "Thickness" },
                values: new object[] { 2, "Red", 50.75m, "Medium", "Silk", "Floral", (short)2 });

            migrationBuilder.InsertData(
                table: "Fabrics",
                columns: new[] { "FabricId", "Color", "CostPerMeter", "Durability", "FabricType", "Pattern", "Thickness" },
                values: new object[] { 3, "Blue", 15.0m, "High", "Polyester", "Striped", (short)3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fabrics",
                keyColumn: "FabricId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fabrics",
                keyColumn: "FabricId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fabrics",
                keyColumn: "FabricId",
                keyValue: 3);
        }
    }
}
