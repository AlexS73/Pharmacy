using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Entity.Migrations
{
    public partial class warehousechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "SaleProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "EntranceProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Управление" });

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_WarehouseId",
                table: "SaleProduct",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_EntranceProduct_WarehouseId",
                table: "EntranceProduct",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceProduct_Warehouse_WarehouseId",
                table: "EntranceProduct",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProduct_Warehouse_WarehouseId",
                table: "SaleProduct",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntranceProduct_Warehouse_WarehouseId",
                table: "EntranceProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleProduct_Warehouse_WarehouseId",
                table: "SaleProduct");

            migrationBuilder.DropIndex(
                name: "IX_SaleProduct_WarehouseId",
                table: "SaleProduct");

            migrationBuilder.DropIndex(
                name: "IX_EntranceProduct_WarehouseId",
                table: "EntranceProduct");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "SaleProduct");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "EntranceProduct");
        }
    }
}
