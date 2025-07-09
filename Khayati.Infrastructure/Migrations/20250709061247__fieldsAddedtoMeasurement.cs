using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class _fieldsAddedtoMeasurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Fabrics_FabricId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_FabricId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "FabricId",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "trousers",
                table: "Measurements",
                newName: "Trousers");

            migrationBuilder.AlterColumn<double>(
                name: "Trousers",
                table: "Measurements",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<double>(
                name: "Waist",
                table: "Measurements",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<double>(
                name: "Sleeve",
                table: "Measurements",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<double>(
                name: "ShoulderWidth",
                table: "Measurements",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<double>(
                name: "Neck",
                table: "Measurements",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<double>(
                name: "Leg",
                table: "Measurements",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Measurements",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<double>(
                name: "Chest",
                table: "Measurements",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<double>(
                name: "ArmLength",
                table: "Measurements",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AddColumn<double>(
                name: "Ankle",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Armhole",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BackWidth",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Bicep",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Bust",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Calf",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FrontLength",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Hip",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Inseam",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Knee",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NeckToWaist",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ShoulderToBust",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ShoulderToWaist",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SkirtLength",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Thigh",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TorsoLength",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UnderBust",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WaistToFloor",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WaistToHip",
                table: "Measurements",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Wrist",
                table: "Measurements",
                type: "REAL",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ankle",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Armhole",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "BackWidth",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Bicep",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Bust",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Calf",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "FrontLength",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Hip",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Inseam",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Knee",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "NeckToWaist",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "ShoulderToBust",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "ShoulderToWaist",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "SkirtLength",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Thigh",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "TorsoLength",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "UnderBust",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "WaistToFloor",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "WaistToHip",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Wrist",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "Trousers",
                table: "Measurements",
                newName: "trousers");

            migrationBuilder.AlterColumn<double>(
                name: "Waist",
                table: "Measurements",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "trousers",
                table: "Measurements",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Sleeve",
                table: "Measurements",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ShoulderWidth",
                table: "Measurements",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Neck",
                table: "Measurements",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Leg",
                table: "Measurements",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Measurements",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Chest",
                table: "Measurements",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ArmLength",
                table: "Measurements",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FabricId",
                table: "Measurements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_FabricId",
                table: "Measurements",
                column: "FabricId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Fabrics_FabricId",
                table: "Measurements",
                column: "FabricId",
                principalTable: "Fabrics",
                principalColumn: "FabricId");
        }
    }
}
