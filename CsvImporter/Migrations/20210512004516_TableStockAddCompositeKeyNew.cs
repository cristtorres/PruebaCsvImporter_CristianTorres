using Microsoft.EntityFrameworkCore.Migrations;

namespace CsvImporter.Migrations
{
    public partial class TableStockAddCompositeKeyNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.AlterColumn<string>(
                name: "Stock",
                table: "Stock",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PointOfSale",
                table: "Stock",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                columns: new[] { "PointOfSale", "Product", "Date", "Stock" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.AlterColumn<string>(
                name: "Stock",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PointOfSale",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                columns: new[] { "Product", "Date" });
        }
    }
}
