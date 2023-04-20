using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Entity.Migrations
{
    public partial class AddedSumForSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Sum",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SaleProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SaleProduct");
        }
    }
}
