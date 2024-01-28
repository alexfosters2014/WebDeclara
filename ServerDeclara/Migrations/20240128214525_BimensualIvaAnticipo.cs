using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerDeclara.Migrations
{
    /// <inheritdoc />
    public partial class BimensualIvaAnticipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BimensualIVAId",
                table: "EntradasIVAsDiarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AnticipoBimestreIVA",
                table: "BimensualesIVA",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_EntradasIVAsDiarios_BimensualIVAId",
                table: "EntradasIVAsDiarios",
                column: "BimensualIVAId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradasIVAsDiarios_BimensualesIVA_BimensualIVAId",
                table: "EntradasIVAsDiarios",
                column: "BimensualIVAId",
                principalTable: "BimensualesIVA",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradasIVAsDiarios_BimensualesIVA_BimensualIVAId",
                table: "EntradasIVAsDiarios");

            migrationBuilder.DropIndex(
                name: "IX_EntradasIVAsDiarios_BimensualIVAId",
                table: "EntradasIVAsDiarios");

            migrationBuilder.DropColumn(
                name: "BimensualIVAId",
                table: "EntradasIVAsDiarios");

            migrationBuilder.DropColumn(
                name: "AnticipoBimestreIVA",
                table: "BimensualesIVA");
        }
    }
}
