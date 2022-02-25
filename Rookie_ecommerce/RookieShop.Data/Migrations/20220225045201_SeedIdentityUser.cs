using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookieShop.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeCreate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 5, DateTimeKind.Local).AddTicks(8969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 10, 54, 39, 653, DateTimeKind.Local).AddTicks(4061));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrdersDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 5, DateTimeKind.Local).AddTicks(757),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 10, 54, 39, 652, DateTimeKind.Local).AddTicks(6533));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "AppUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 6, DateTimeKind.Local).AddTicks(3253),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 10, 54, 39, 653, DateTimeKind.Local).AddTicks(7836));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("84c8304c-c52a-42bf-a985-36fb0b00743b"), "62c72394-3a3d-421a-870f-61f72df95197", "Adminstrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("84c8304c-c52a-42bf-a985-36fb0b00743b"), new Guid("5a33f896-2359-44ff-82fd-b6d33786ac2a") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("5a33f896-2359-44ff-82fd-b6d33786ac2a"), 0, "05dbbcc0-51a4-4e48-bb9f-b28a30ccfc19", new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "luanhuu2000@gmail.com", true, "Luan", "Pham", false, null, "luanhuu2000@gmail.com", "admin", "AQAAAAEAACcQAAAAELkK+rKN9TI16U2ksVGZUIlDQwpjy76rznLKdXSLvB2N8IH0SICn0b8iI6yUJp9GIQ==", null, false, "", false, "admin" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("84c8304c-c52a-42bf-a985-36fb0b00743b"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("84c8304c-c52a-42bf-a985-36fb0b00743b"), new Guid("5a33f896-2359-44ff-82fd-b6d33786ac2a") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5a33f896-2359-44ff-82fd-b6d33786ac2a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeCreate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 10, 54, 39, 653, DateTimeKind.Local).AddTicks(4061),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 5, DateTimeKind.Local).AddTicks(8969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrdersDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 10, 54, 39, 652, DateTimeKind.Local).AddTicks(6533),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 5, DateTimeKind.Local).AddTicks(757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "AppUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 10, 54, 39, 653, DateTimeKind.Local).AddTicks(7836),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 11, 52, 0, 6, DateTimeKind.Local).AddTicks(3253));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreate",
                value: new DateTime(2022, 2, 25, 10, 54, 39, 654, DateTimeKind.Local).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeCreate",
                value: new DateTime(2022, 2, 25, 10, 54, 39, 654, DateTimeKind.Local).AddTicks(94));
        }
    }
}
