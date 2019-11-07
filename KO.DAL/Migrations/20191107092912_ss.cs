using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KO.DAL.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 7, 12, 29, 11, 841, DateTimeKind.Local).AddTicks(6241));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 6, 23, 28, 2, 840, DateTimeKind.Local).AddTicks(7174));
        }
    }
}
