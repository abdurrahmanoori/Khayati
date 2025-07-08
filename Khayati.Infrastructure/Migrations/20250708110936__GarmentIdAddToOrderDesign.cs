using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class _GarmentIdAddToOrderDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GarmentId",
                table: "OrderDesigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "RequiredMeters",
                table: "Fabrics",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "FabricId",
                keyValue: 1,
                column: "RequiredMeters",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "FabricId",
                keyValue: 2,
                column: "RequiredMeters",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "FabricId",
                keyValue: 3,
                column: "RequiredMeters",
                value: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GarmentId",
                table: "OrderDesigns");

            migrationBuilder.AlterColumn<float>(
                name: "RequiredMeters",
                table: "Fabrics",
                type: "REAL",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "FabricId",
                keyValue: 1,
                column: "RequiredMeters",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "FabricId",
                keyValue: 2,
                column: "RequiredMeters",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "Fabrics",
                keyColumn: "FabricId",
                keyValue: 3,
                column: "RequiredMeters",
                value: 0f);
        }
    }
}
