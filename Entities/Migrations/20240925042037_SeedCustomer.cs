using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class SeedCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType", "DateOfBirth", "EmailAddress", "NationalID", "PhoneNumber" },
                values: new object[] { 1, "123 Main St, Springfield", "John Doe", new DateTime(2010, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regular", new DateTime(1985, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@example.com", "1234567890", "123-456-7890" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType", "DateOfBirth", "EmailAddress", "NationalID", "PhoneNumber" },
                values: new object[] { 2, "456 Elm St, Springfield", "Jane Smith", new DateTime(2015, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIP", new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "janesmith@example.com", "0987654321", "987-654-3210" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType", "DateOfBirth", "EmailAddress", "NationalID", "PhoneNumber" },
                values: new object[] { 3, "789 Oak St, Metropolis", "Robert Brown", new DateTime(2008, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate", new DateTime(1975, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "robertbrown@example.com", "4567890123", "555-123-4567" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType", "DateOfBirth", "EmailAddress", "NationalID", "PhoneNumber" },
                values: new object[] { 4, "321 Pine St, Gotham", "Emily Davis", new DateTime(2017, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regular", new DateTime(1992, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "emilydavis@example.com", "3216549870", "321-654-9870" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "CustomerSince", "CustomerType", "DateOfBirth", "EmailAddress", "NationalID", "PhoneNumber" },
                values: new object[] { 5, "654 Maple St, Star City", "Michael Johnson", new DateTime(2005, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIP", new DateTime(1980, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "michaeljohnson@example.com", "9876543210", "777-888-9999" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);
        }
    }
}
