using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Entity.Migrations
{
    public partial class ChangeKeyForCharacteristic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacteristicProduct_Characteristics_CharacteristicsId",
                table: "CharacteristicProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Characteristics_CharacteristicTypes_TypeId",
                table: "Characteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characteristics",
                table: "Characteristics");

            migrationBuilder.DropIndex(
                name: "IX_Characteristics_TypeId",
                table: "Characteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacteristicProduct",
                table: "CharacteristicProduct");

            migrationBuilder.DropIndex(
                name: "IX_CharacteristicProduct_ProductsId",
                table: "CharacteristicProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Characteristics");

            migrationBuilder.RenameColumn(
                name: "CharacteristicsId",
                table: "CharacteristicProduct",
                newName: "CharacteristicsTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Characteristics",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Characteristics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharacteristicsValue",
                table: "CharacteristicProduct",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characteristics",
                table: "Characteristics",
                columns: new[] { "TypeId", "Value" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacteristicProduct",
                table: "CharacteristicProduct",
                columns: new[] { "ProductsId", "CharacteristicsTypeId", "CharacteristicsValue" });

            migrationBuilder.CreateIndex(
                name: "IX_CharacteristicProduct_CharacteristicsTypeId_CharacteristicsValue",
                table: "CharacteristicProduct",
                columns: new[] { "CharacteristicsTypeId", "CharacteristicsValue" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharacteristicProduct_Characteristics_CharacteristicsTypeId_CharacteristicsValue",
                table: "CharacteristicProduct",
                columns: new[] { "CharacteristicsTypeId", "CharacteristicsValue" },
                principalTable: "Characteristics",
                principalColumns: new[] { "TypeId", "Value" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristics_CharacteristicTypes_TypeId",
                table: "Characteristics",
                column: "TypeId",
                principalTable: "CharacteristicTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacteristicProduct_Characteristics_CharacteristicsTypeId_CharacteristicsValue",
                table: "CharacteristicProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Characteristics_CharacteristicTypes_TypeId",
                table: "Characteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characteristics",
                table: "Characteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacteristicProduct",
                table: "CharacteristicProduct");

            migrationBuilder.DropIndex(
                name: "IX_CharacteristicProduct_CharacteristicsTypeId_CharacteristicsValue",
                table: "CharacteristicProduct");

            migrationBuilder.DropColumn(
                name: "CharacteristicsValue",
                table: "CharacteristicProduct");

            migrationBuilder.RenameColumn(
                name: "CharacteristicsTypeId",
                table: "CharacteristicProduct",
                newName: "CharacteristicsId");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Characteristics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Characteristics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Characteristics",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characteristics",
                table: "Characteristics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacteristicProduct",
                table: "CharacteristicProduct",
                columns: new[] { "CharacteristicsId", "ProductsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_TypeId",
                table: "Characteristics",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacteristicProduct_ProductsId",
                table: "CharacteristicProduct",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacteristicProduct_Characteristics_CharacteristicsId",
                table: "CharacteristicProduct",
                column: "CharacteristicsId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristics_CharacteristicTypes_TypeId",
                table: "Characteristics",
                column: "TypeId",
                principalTable: "CharacteristicTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
