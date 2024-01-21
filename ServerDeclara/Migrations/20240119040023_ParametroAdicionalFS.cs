using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerDeclara.Migrations
{
    /// <inheritdoc />
    public partial class ParametroAdicionalFS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "Atributo", "Descripcion", "Formula", "HistorialParametroId", "IngresosDesde", "IngresosHasta", "Orden", "Tasa", "Tipo", "ValidezParametrosDesde", "ValidezParametrosHasta" },
                values: new object[] { 24, "AdicionalFondoSolidaridad", "Valor adicional Fondo de solidaridad", "IIF(AdicionalFS = true, 786, 0)", 1, 0.0, 0.0, 24, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
