using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Entity.Migrations
{
    public partial class removeWarehouseOperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarehouseOperations");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Warehouse",
                newName: "Stock");

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "Entrances",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Entrances");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Warehouse",
                newName: "Count");

            migrationBuilder.CreateTable(
                name: "WarehouseOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseOperations_ProductOperations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "ProductOperations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseOperations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseOperations_OperationId",
                table: "WarehouseOperations",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseOperations_ProductId",
                table: "WarehouseOperations",
                column: "ProductId");
        }
    }
}
