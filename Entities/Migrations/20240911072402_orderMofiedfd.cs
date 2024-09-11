using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class orderMofiedfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designs_Customers_CustomerID",
                table: "Designs");

            migrationBuilder.DropForeignKey(
                name: "FK_Designs_Measurements_MeasurementID",
                table: "Designs");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Designs_DesignID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DesignID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DesignDescription",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "DesignName",
                table: "Designs");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "DesignID",
                table: "Orders",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameColumn(
                name: "MeasurementID",
                table: "Measurements",
                newName: "Measurementid");

            migrationBuilder.RenameColumn(
                name: "MeasurementID",
                table: "Designs",
                newName: "MeasurementId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Designs",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "DesignID",
                table: "Designs",
                newName: "DesignId");

            migrationBuilder.RenameIndex(
                name: "IX_Designs_MeasurementID",
                table: "Designs",
                newName: "IX_Designs_MeasurementId");

            migrationBuilder.RenameIndex(
                name: "IX_Designs_CustomerID",
                table: "Designs",
                newName: "IX_Designs_CustomerId");

            migrationBuilder.AlterColumn<int>(
                name: "OrdersId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Embellish",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmblishId",
                table: "Designs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Designs_EmblishId",
                table: "Designs",
                column: "EmblishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Designs_Customers_CustomerId",
                table: "Designs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Designs_Measurements_EmblishId",
                table: "Designs",
                column: "EmblishId",
                principalTable: "Measurements",
                principalColumn: "Measurementid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Designs_Measurements_MeasurementId",
                table: "Designs",
                column: "MeasurementId",
                principalTable: "Measurements",
                principalColumn: "Measurementid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designs_Customers_CustomerId",
                table: "Designs");

            migrationBuilder.DropForeignKey(
                name: "FK_Designs_Measurements_EmblishId",
                table: "Designs");

            migrationBuilder.DropForeignKey(
                name: "FK_Designs_Measurements_MeasurementId",
                table: "Designs");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Designs_EmblishId",
                table: "Designs");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Embellish");

            migrationBuilder.DropColumn(
                name: "EmblishId",
                table: "Designs");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "Orders",
                newName: "DesignID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerID");

            migrationBuilder.RenameColumn(
                name: "Measurementid",
                table: "Measurements",
                newName: "MeasurementID");

            migrationBuilder.RenameColumn(
                name: "MeasurementId",
                table: "Designs",
                newName: "MeasurementID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Designs",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "DesignId",
                table: "Designs",
                newName: "DesignID");

            migrationBuilder.RenameIndex(
                name: "IX_Designs_MeasurementId",
                table: "Designs",
                newName: "IX_Designs_MeasurementID");

            migrationBuilder.RenameIndex(
                name: "IX_Designs_CustomerId",
                table: "Designs",
                newName: "IX_Designs_CustomerID");

            migrationBuilder.AlterColumn<int>(
                name: "DesignID",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "DesignDescription",
                table: "Designs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DesignName",
                table: "Designs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DesignID",
                table: "Orders",
                column: "DesignID");

            migrationBuilder.AddForeignKey(
                name: "FK_Designs_Customers_CustomerID",
                table: "Designs",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Designs_Measurements_MeasurementID",
                table: "Designs",
                column: "MeasurementID",
                principalTable: "Measurements",
                principalColumn: "MeasurementID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Designs_DesignID",
                table: "Orders",
                column: "DesignID",
                principalTable: "Designs",
                principalColumn: "DesignID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
