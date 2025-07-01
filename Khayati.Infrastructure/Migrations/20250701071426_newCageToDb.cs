using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class newCageToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Embellishment_EmbellishmentTypes_EmbellishmentTypeId",
                table: "Embellishment");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "OrderDesigns",
                newName: "Details");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedCompletionDate",
                table: "Orders",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "OrderPriority",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDesigns_MeasurementId",
                table: "OrderDesigns",
                column: "MeasurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Embellishment_EmbellishmentTypes_EmbellishmentTypeId",
                table: "Embellishment",
                column: "EmbellishmentTypeId",
                principalTable: "EmbellishmentTypes",
                principalColumn: "EmbellishmentTypeId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Embellishment_EmbellishmentTypes_EmbellishmentTypeId",
                table: "Embellishment");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDesigns_Measurements_MeasurementId",
                table: "OrderDesigns");

            migrationBuilder.DropIndex(
                name: "IX_OrderDesigns_MeasurementId",
                table: "OrderDesigns");

            migrationBuilder.DropColumn(
                name: "OrderPriority",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "OrderDesigns",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpectedCompletionDate",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Embellishment_EmbellishmentTypes_EmbellishmentTypeId",
                table: "Embellishment",
                column: "EmbellishmentTypeId",
                principalTable: "EmbellishmentTypes",
                principalColumn: "EmbellishmentTypeId");
        }
    }
}
