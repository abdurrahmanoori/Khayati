using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class AddColorToOrderDesn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FabricColor",
                table: "OrderDesigns",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FabricColor",
                table: "OrderDesigns");
        }
    }
}
