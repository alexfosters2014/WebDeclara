using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerDeclara.Migrations
{
    /// <inheritdoc />
    public partial class HistorialParametrosBimensual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistorialParametroId",
                table: "BimensualesRPFs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BimensualesRPFs_HistorialParametroId",
                table: "BimensualesRPFs",
                column: "HistorialParametroId");

            migrationBuilder.AddForeignKey(
                name: "FK_BimensualesRPFs_HistorialParametros_HistorialParametroId",
                table: "BimensualesRPFs",
                column: "HistorialParametroId",
                principalTable: "HistorialParametros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BimensualesRPFs_HistorialParametros_HistorialParametroId",
                table: "BimensualesRPFs");

            migrationBuilder.DropIndex(
                name: "IX_BimensualesRPFs_HistorialParametroId",
                table: "BimensualesRPFs");

            migrationBuilder.DropColumn(
                name: "HistorialParametroId",
                table: "BimensualesRPFs");
        }
    }
}
