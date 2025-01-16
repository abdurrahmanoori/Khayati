using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class AddDescInMeasurment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Measurementid",
                table: "Measurements",
                newName: "MeasurementId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Measurements",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "MeasurementId",
                table: "Measurements",
                newName: "Measurementid");
        }
    }
}
