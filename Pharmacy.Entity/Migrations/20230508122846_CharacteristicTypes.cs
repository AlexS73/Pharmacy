using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Entity.Migrations
{
    public partial class CharacteristicTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Characteristics");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Characteristics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharacteristicTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacteristicTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_TypeId",
                table: "Characteristics",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristics_CharacteristicTypes_TypeId",
                table: "Characteristics",
                column: "TypeId",
                principalTable: "CharacteristicTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characteristics_CharacteristicTypes_TypeId",
                table: "Characteristics");

            migrationBuilder.DropTable(
                name: "CharacteristicTypes");

            migrationBuilder.DropIndex(
                name: "IX_Characteristics_TypeId",
                table: "Characteristics");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Characteristics");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Characteristics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
