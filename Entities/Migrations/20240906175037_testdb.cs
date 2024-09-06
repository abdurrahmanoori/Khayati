using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class testdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Customers_CustomerID",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Measurements",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_CustomerID",
                table: "Measurements",
                newName: "IX_Measurements_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Customers_CustomerId",
                table: "Measurements",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Customers_CustomerId",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Measurements",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_CustomerId",
                table: "Measurements",
                newName: "IX_Measurements_CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Customers_CustomerID",
                table: "Measurements",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
