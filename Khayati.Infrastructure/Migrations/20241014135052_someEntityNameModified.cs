using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class someEntityNameModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerSince",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerType",
                table: "Customers",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "NationalID",
                table: "Customers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Customers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Relative",
                columns: table => new
                {
                    RelativeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    RelationshipType = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relative", x => x.RelativeId);
                    table.ForeignKey(
                        name: "FK_Relative_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "Address", "Name" },
                values: new object[] { "123 Main St, Springfield", "John Doe" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "Address", "Name" },
                values: new object[] { "456 Elm St, Springfield", "Jane Smith" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "Address", "Name" },
                values: new object[] { "789 Oak St, Metropolis", "Robert Brown" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                columns: new[] { "Address", "Name" },
                values: new object[] { "321 Pine St, Gotham", "Emily Davis" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                columns: new[] { "Address", "Name" },
                values: new object[] { "654 Maple St, Star City", "Michael Johnson" });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8474));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 18, 20, 51, 438, DateTimeKind.Local).AddTicks(8475));

            migrationBuilder.CreateIndex(
                name: "IX_Relative_CustomerId",
                table: "Relative",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relative");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "CustomerType");

            migrationBuilder.AlterColumn<string>(
                name: "NationalID",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CustomerSince",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType" },
                values: new object[] { "123 Main St, Springfield", "John Doe", new DateTime(2010, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regular" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType" },
                values: new object[] { "456 Elm St, Springfield", "Jane Smith", new DateTime(2015, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIP" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType" },
                values: new object[] { "789 Oak St, Metropolis", "Robert Brown", new DateTime(2008, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                columns: new[] { "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType" },
                values: new object[] { "321 Pine St, Gotham", "Emily Davis", new DateTime(2017, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regular" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                columns: new[] { "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType" },
                values: new object[] { "654 Maple St, Star City", "Michael Johnson", new DateTime(2005, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIP" });

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 12, 22, 23, 50, 995, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 12, 22, 23, 50, 995, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 12, 22, 23, 50, 995, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Measurementid",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 12, 22, 23, 50, 995, DateTimeKind.Local).AddTicks(9496));
        }
    }
}
