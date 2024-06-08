using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloProjectFinal.Migrations
{
    public partial class UserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 8, 22, 7, 16, 862, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 8, 22, 7, 16, 862, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 8, 22, 7, 16, 862, DateTimeKind.Local).AddTicks(8240));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 7, 19, 58, 34, 492, DateTimeKind.Local).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 7, 19, 58, 34, 492, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 7, 19, 58, 34, 492, DateTimeKind.Local).AddTicks(6540));
        }
    }
}
