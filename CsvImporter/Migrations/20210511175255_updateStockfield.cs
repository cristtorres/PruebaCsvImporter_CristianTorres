using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CsvImporter.Migrations
{
    public partial class updateStockfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStock",
                table: "Stock");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Stock",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Stock");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Stock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStock",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
