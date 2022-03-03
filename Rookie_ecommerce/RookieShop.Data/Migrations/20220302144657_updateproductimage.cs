using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookieShop.Data.Migrations
{
    public partial class updateproductimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeCreate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 5, DateTimeKind.Local).AddTicks(8969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrdersDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 5, DateTimeKind.Local).AddTicks(757));

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "AppUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 2, 21, 46, 56, 794, DateTimeKind.Local).AddTicks(5205),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 6, DateTimeKind.Local).AddTicks(3253));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("84c8304c-c52a-42bf-a985-36fb0b00743b"),
                column: "ConcurrencyStamp",
                value: "9b616b2b-2f89-4d05-ac88-33f77ec5b57e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5a33f896-2359-44ff-82fd-b6d33786ac2a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1c4fad7-9753-4f95-8b05-cd351f4415e3", "AQAAAAEAACcQAAAAEGJQfkgSJQg7cCdqmVav5Sx4FfLKp+AVyyZePZE42emmkIUpfzO4mfN9uwKrh6uP7Q==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreate",
                value: new DateTime(2022, 3, 2, 21, 46, 56, 794, DateTimeKind.Local).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeCreate",
                value: new DateTime(2022, 3, 2, 21, 46, 56, 794, DateTimeKind.Local).AddTicks(7328));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Images");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeCreate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 5, DateTimeKind.Local).AddTicks(8969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrdersDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 5, DateTimeKind.Local).AddTicks(757),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "AppUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 6, DateTimeKind.Local).AddTicks(3253),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 2, 21, 46, 56, 794, DateTimeKind.Local).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("84c8304c-c52a-42bf-a985-36fb0b00743b"),
                column: "ConcurrencyStamp",
                value: "62c72394-3a3d-421a-870f-61f72df95197");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5a33f896-2359-44ff-82fd-b6d33786ac2a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "05dbbcc0-51a4-4e48-bb9f-b28a30ccfc19", "AQAAAAEAACcQAAAAELkK+rKN9TI16U2ksVGZUIlDQwpjy76rznLKdXSLvB2N8IH0SICn0b8iI6yUJp9GIQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreate",
                value: new DateTime(2022, 2, 25, 11, 52, 0, 6, DateTimeKind.Local).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeCreate",
                value: new DateTime(2022, 2, 25, 11, 52, 0, 6, DateTimeKind.Local).AddTicks(5741));
        }
    }
}
