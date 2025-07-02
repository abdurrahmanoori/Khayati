using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class addCostInOrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Measurements");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Orders",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Measurements",
                type: "TEXT",
                nullable: true);
        }
    }
}
