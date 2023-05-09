using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Entity.Migrations
{
    public partial class CharacteristicTypesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CharacteristicTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Категория" });

            migrationBuilder.InsertData(
                table: "CharacteristicTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Срок годности" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacteristicTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CharacteristicTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
