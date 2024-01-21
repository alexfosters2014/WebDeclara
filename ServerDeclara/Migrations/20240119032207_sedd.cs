using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerDeclara.Migrations
{
    /// <inheritdoc />
    public partial class sedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Atributo", "Formula" },
                values: new object[] { "BPC", "5660" });

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 12,
                column: "Formula",
                value: "IIF((IngDependenciaCess + IngDependenciaNoCess + IngSalVacacional) > (BPC * 10), IngDependenciaCess * 0.06, 0)");

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 18,
                column: "Formula",
                value: "IIF(AdicionalFS = true,5/3 * BPC / 12, 0)");

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 19,
                column: "Formula",
                value: "IIF(AnticipoNF = false, LiquidacionMes, LiquidacionMes * 0.95)");

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 20,
                column: "Formula",
                value: "IIF(TotalExcedenteIngresos > (15 * BPC), 0.08, 0.14)");

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "Atributo", "Descripcion", "Formula", "HistorialParametroId", "IngresosDesde", "IngresosHasta", "Orden", "Tasa", "Tipo", "ValidezParametrosDesde", "ValidezParametrosHasta" },
                values: new object[,]
                {
                    { 21, "TotalExcedenteIngresos", "Ingresos exc. AG y SV", "IngParaAnticipo - IngIncrementoSeisPorciento - IngSalVacacional - DeduccionLegalIngresos", 1, 0.0, 0.0, 21, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "TotalDeducible", "Total deducible para liquidacion", "DeduccionTotal * TasaDeduccion", 1, 0.0, 0.0, 22, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "LiquidacionMes", "Liquidacion mes", "IIF((LiquidacionIngresos - TotalDeducible)>0,(LiquidacionIngresos -TotalDeducible),0)", 1, 0.0, 0.0, 23, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Atributo", "Formula" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 12,
                column: "Formula",
                value: "IFF((IngDependenciaCess + IngDependenciaNoCess + IngSalVacacional) > (BPC * 10), IngDependenciaCess * 0.06, 0)");

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 18,
                column: "Formula",
                value: "IFF(AdicionalFS = true,5/3 * BPC / 12, 0)");

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 19,
                column: "Formula",
                value: "IFF(AnticipoNF = false, LiquidacionMes, LiquidacionMes * 0.95)");

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 20,
                column: "Formula",
                value: "IFF(IngresosExc > (15 * BPC), 0.8, 0.14)");
        }
    }
}
