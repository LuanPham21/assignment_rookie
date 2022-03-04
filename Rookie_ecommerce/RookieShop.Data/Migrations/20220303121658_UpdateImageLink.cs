using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookieShop.Data.Migrations
{
    public partial class UpdateImageLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "AppUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 3, 19, 16, 57, 809, DateTimeKind.Local).AddTicks(8312),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 2, 22, 30, 13, 124, DateTimeKind.Local).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("84c8304c-c52a-42bf-a985-36fb0b00743b"),
                column: "ConcurrencyStamp",
                value: "d9f84124-4989-46a2-9ce0-50de2aa7172e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5a33f896-2359-44ff-82fd-b6d33786ac2a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eff71da9-499a-45ee-8d71-59f15f02e3bd", "AQAAAAEAACcQAAAAEKTDhcTc2AmlLTasRzR/bSLM00NqZIoG0EoBkTTirlytPnbCOHO2WsihNs7lB1nfjg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreate",
                value: new DateTime(2022, 3, 3, 19, 16, 57, 810, DateTimeKind.Local).AddTicks(393));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeCreate",
                value: new DateTime(2022, 3, 3, 19, 16, 57, 810, DateTimeKind.Local).AddTicks(398));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "AppUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 2, 22, 30, 13, 124, DateTimeKind.Local).AddTicks(4097),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 3, 19, 16, 57, 809, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("84c8304c-c52a-42bf-a985-36fb0b00743b"),
                column: "ConcurrencyStamp",
                value: "25a17fd8-fc03-4978-9e87-4f9dbacc800c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5a33f896-2359-44ff-82fd-b6d33786ac2a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d12041bd-7302-4c26-ae47-a48bc01096f8", "AQAAAAEAACcQAAAAELbLcSY1ooQdXcWjPDx0D8BywXN8hknrvdLpymdmC7/AGVpdE64sespMpX+ivSv9tw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeCreate",
                value: new DateTime(2022, 3, 2, 22, 30, 13, 124, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeCreate",
                value: new DateTime(2022, 3, 2, 22, 30, 13, 124, DateTimeKind.Local).AddTicks(6204));
        }
    }
}
