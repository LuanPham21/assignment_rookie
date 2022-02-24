using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookieShop.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeCreate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 1, 11, 12, 405, DateTimeKind.Local).AddTicks(3438),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 24, 23, 6, 38, 593, DateTimeKind.Local).AddTicks(6452));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrdersDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 1, 11, 12, 404, DateTimeKind.Local).AddTicks(7795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 24, 23, 6, 38, 592, DateTimeKind.Local).AddTicks(7282));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentId", "Status" },
                values: new object[,]
                {
                    { 1, "Bánh kem", null, 1 },
                    { 2, "Bánh socola", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Details", "Name", "OriginalPrice", "Price", "Quantity", "Status", "TimeCreate", "ViewCount" },
                values: new object[,]
                {
                    { 1, "Bánh kem được làm từ dâu tự nhiên", "Bánh kem được làm từ dâu tự nhiên", "Bánh kem vị dâu", 10000m, 20000m, 100, 1, new DateTime(2022, 2, 25, 1, 11, 12, 405, DateTimeKind.Local).AddTicks(6856), 1 },
                    { 2, "Bánh socola được làm từ socola trắng với hạnh nhân", "Bánh socola được làm từ socola trắng với hạnh nhân", "Bánh socola", 10000m, 20000m, 100, 1, new DateTime(2022, 2, 25, 1, 11, 12, 405, DateTimeKind.Local).AddTicks(6862), 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductsInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductsInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductsInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeCreate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 24, 23, 6, 38, 593, DateTimeKind.Local).AddTicks(6452),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 1, 11, 12, 405, DateTimeKind.Local).AddTicks(3438));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrdersDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 24, 23, 6, 38, 592, DateTimeKind.Local).AddTicks(7282),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 1, 11, 12, 404, DateTimeKind.Local).AddTicks(7795));
        }
    }
}
