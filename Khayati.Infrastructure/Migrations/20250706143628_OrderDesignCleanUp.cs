using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class OrderDesignCleanUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDesigns_Customers_CustomerId",
                table: "OrderDesigns");

            migrationBuilder.DropIndex(
                name: "IX_OrderDesigns_CustomerId",
                table: "OrderDesigns");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OrderDesigns");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "OrderDesigns");

            migrationBuilder.AlterColumn<float>(
                name: "RequiredMeters",
                table: "Fabrics",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL");

            //migrationBuilder.UpdateData(
            //    table: "Fabrics",
            //    keyColumn: "FabricId",
            //    keyValue: 1,
            //    column: "RequiredMeters",
            //    value: null);

            //migrationBuilder.UpdateData(
            //    table: "Fabrics",
            //    keyColumn: "FabricId",
            //    keyValue: 2,
            //    column: "RequiredMeters",
            //    value: null);

            //migrationBuilder.UpdateData(
            //    table: "Fabrics",
            //    keyColumn: "FabricId",
            //    keyValue: 3,
            //    column: "RequiredMeters",
            //    value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "OrderDesigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "OrderDesigns",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "RequiredMeters",
                table: "Fabrics",
                type: "REAL",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            //migrationBuilder.UpdateData(
            //    table: "Fabrics",
            //    keyColumn: "FabricId",
            //    keyValue: 1,
            //    column: "RequiredMeters",
            //    value: 0f);

            //migrationBuilder.UpdateData(
            //    table: "Fabrics",
            //    keyColumn: "FabricId",
            //    keyValue: 2,
            //    column: "RequiredMeters",
            //    value: 0f);

            //migrationBuilder.UpdateData(
            //    table: "Fabrics",
            //    keyColumn: "FabricId",
            //    keyValue: 3,
            //    column: "RequiredMeters",
            //    value: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDesigns_CustomerId",
                table: "OrderDesigns",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDesigns_Customers_CustomerId",
                table: "OrderDesigns",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
