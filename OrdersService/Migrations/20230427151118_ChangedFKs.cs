using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrdersService.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("253232ad-4a23-4f14-99e2-4776c2f14cfe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9159b6f0-6135-438c-83fe-146c5e213b15"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b466456e-a3ed-4e05-8ce4-ffd483c19335"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7054e065-946f-4c07-b603-9a50103acaae"), "Notebook" },
                    { new Guid("946f34f1-af13-4557-9743-39d4beca44fb"), "Phone" },
                    { new Guid("eccea7ae-ed79-4848-b205-c05b9cad362d"), "Computer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7054e065-946f-4c07-b603-9a50103acaae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("946f34f1-af13-4557-9743-39d4beca44fb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eccea7ae-ed79-4848-b205-c05b9cad362d"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("253232ad-4a23-4f14-99e2-4776c2f14cfe"), "Notebook" },
                    { new Guid("9159b6f0-6135-438c-83fe-146c5e213b15"), "Computer" },
                    { new Guid("b466456e-a3ed-4e05-8ce4-ffd483c19335"), "Phone" }
                });
        }
    }
}
