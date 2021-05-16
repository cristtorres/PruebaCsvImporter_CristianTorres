using Microsoft.EntityFrameworkCore.Migrations;

namespace CsvImporter.Migrations
{
    public partial class newTableStockSinId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Stock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Stock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Id");
        }
    }
}
