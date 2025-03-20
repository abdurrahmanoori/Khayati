using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class fliedNullablmeasuremntInOrderDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderDesigns_MeasurementId",
                table: "OrderDesigns",
                column: "MeasurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDesigns_Measurements_MeasurementId",
                table: "OrderDesigns",
                column: "MeasurementId",
                principalTable: "Measurements",
                principalColumn: "MeasurementId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDesigns_Measurements_MeasurementId",
                table: "OrderDesigns");

            migrationBuilder.DropIndex(
                name: "IX_OrderDesigns_MeasurementId",
                table: "OrderDesigns");
        }
    }
}
