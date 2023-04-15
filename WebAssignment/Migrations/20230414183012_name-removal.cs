using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAssignment.Migrations
{
    public partial class nameremoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lname",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "AuctionStart",
                value: new DateTime(2023, 4, 14, 14, 30, 11, 800, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "AuctionStart",
                value: new DateTime(2023, 4, 14, 14, 30, 11, 800, DateTimeKind.Local).AddTicks(7896));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "AuctionStart",
                value: new DateTime(2023, 4, 14, 14, 25, 24, 695, DateTimeKind.Local).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "AuctionStart",
                value: new DateTime(2023, 4, 14, 14, 25, 24, 695, DateTimeKind.Local).AddTicks(1731));
        }
    }
}
