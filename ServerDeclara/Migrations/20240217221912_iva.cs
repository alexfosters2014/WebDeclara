using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerDeclara.Migrations
{
    /// <inheritdoc />
    public partial class iva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradasIVAsDiarios_BimensualesIVA_BimensualIVAId",
                table: "EntradasIVAsDiarios");

            migrationBuilder.DropForeignKey(
                name: "FK_EntradasIVAsDiarios_EntradasIVAsDiarios_EntradaIvaDiarioId",
                table: "EntradasIVAsDiarios");

            migrationBuilder.DropIndex(
                name: "IX_EntradasIVAsDiarios_EntradaIvaDiarioId",
                table: "EntradasIVAsDiarios");

            migrationBuilder.DropColumn(
                name: "EntradaIvaDiarioId",
                table: "EntradasIVAsDiarios");

            migrationBuilder.AlterColumn<int>(
                name: "BimensualIVAId",
                table: "EntradasIVAsDiarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EntradasIVAsDiarios_BimensualesIVA_BimensualIVAId",
                table: "EntradasIVAsDiarios",
                column: "BimensualIVAId",
                principalTable: "BimensualesIVA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradasIVAsDiarios_BimensualesIVA_BimensualIVAId",
                table: "EntradasIVAsDiarios");

            migrationBuilder.AlterColumn<int>(
                name: "BimensualIVAId",
                table: "EntradasIVAsDiarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EntradaIvaDiarioId",
                table: "EntradasIVAsDiarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntradasIVAsDiarios_EntradaIvaDiarioId",
                table: "EntradasIVAsDiarios",
                column: "EntradaIvaDiarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradasIVAsDiarios_BimensualesIVA_BimensualIVAId",
                table: "EntradasIVAsDiarios",
                column: "BimensualIVAId",
                principalTable: "BimensualesIVA",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradasIVAsDiarios_EntradasIVAsDiarios_EntradaIvaDiarioId",
                table: "EntradasIVAsDiarios",
                column: "EntradaIvaDiarioId",
                principalTable: "EntradasIVAsDiarios",
                principalColumn: "Id");
        }
    }
}
