using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class columnNameChangeInOrderDesingToCostAtTimeOfOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderDesigns",
                newName: "CostAtTimeOfOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CostAtTimeOfOrder",
                table: "OrderDesigns",
                newName: "Price");
        }
    }
}
