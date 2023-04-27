using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrdersService.Migrations
{
    /// <inheritdoc />
    public partial class ChangedKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_ProductId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_OrderId",
                table: "OrderLines");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2500ca62-46d7-4e26-be7e-316388a48063"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8a0ae38c-b665-4272-aa3c-be76283144ac"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("97a4001e-a9a6-47fb-b5df-fe7b774e6bf6"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("253232ad-4a23-4f14-99e2-4776c2f14cfe"), "Notebook" },
                    { new Guid("9159b6f0-6135-438c-83fe-146c5e213b15"), "Computer" },
                    { new Guid("b466456e-a3ed-4e05-8ce4-ffd483c19335"), "Phone" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_OrderId",
                table: "OrderLines",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_OrderId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines");

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
                    { new Guid("2500ca62-46d7-4e26-be7e-316388a48063"), "Notebook" },
                    { new Guid("8a0ae38c-b665-4272-aa3c-be76283144ac"), "Phone" },
                    { new Guid("97a4001e-a9a6-47fb-b5df-fe7b774e6bf6"), "Computer" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_ProductId",
                table: "OrderLines",
                column: "ProductId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_OrderId",
                table: "OrderLines",
                column: "OrderId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
