using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerDeclara.Migrations
{
    /// <inheritdoc />
    public partial class ComprobanteEntradaIVA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comprobante",
                table: "EntradasIVAsDiarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comprobante",
                table: "EntradasIVAsDiarios");
        }
    }
}
