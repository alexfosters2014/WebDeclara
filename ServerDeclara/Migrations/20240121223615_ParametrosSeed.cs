using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerDeclara.Migrations
{
    /// <inheritdoc />
    public partial class ParametrosSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HistorialParametros",
                columns: new[] { "Id", "Descripcion", "Fecha" },
                values: new object[] { 2, "Periodo enero-diciembre 2023", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "Atributo", "Descripcion", "Formula", "HistorialParametroId", "IngresosDesde", "IngresosHasta", "Orden", "Tasa", "Tipo", "ValidezParametrosDesde", "ValidezParametrosHasta" },
                values: new object[,]
                {
                    { 24, "", "0 A 7 BPC", "", 2, 0.0, 7.0, 3, 0.0, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "", "7 A 10 BPC", "", 2, 7.0, 10.0, 6, 0.10000000000000001, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "", "10 A 15 BPC", "", 2, 10.0, 15.0, 9, 0.14999999999999999, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "", "15 A 30 BPC", "", 2, 15.0, 30.0, 12, 0.23999999999999999, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "", "30 A 50 BPC", "", 2, 30.0, 50.0, 15, 0.25, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "", "50 A 75 BPC", "", 2, 50.0, 75.0, 18, 0.27000000000000002, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, "", "75 A 115 BPC", "", 2, 75.0, 115.0, 21, 0.31, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, "", "> BPC", "", 2, 115.0, 20000.0, 24, 0.35999999999999999, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, "BPC", "BPC", "5660", 2, 0.0, 0.0, 9, 5660.0, "BPC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, "DeduccionLegalIngresos", "Deducción legal 30%", "IngIndependiente * -0.3", 2, 0.0, 0.0, 10, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, "IngTotalIndependiente", "Total ingresos fuera de la relación de dependencia", "IngIndependiente + DeduccionLegalIngresos", 2, 0.0, 0.0, 11, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, "IngIncrementoSeisPorciento", "Incremento del 6%", "IIF((IngDependenciaCess + IngDependenciaNoCess + IngSalVacacional) > (BPC * 10), IngDependenciaCess * 0.06, 0)", 2, 0.0, 0.0, 12, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, "IngTotalDependencia", "Ingresos totales en realaciòn de dependencia", "IngDependenciaCess + IngDependenciaNoCess + IngSalVacacional + IngIncrementoSeisPorciento", 2, 0.0, 0.0, 13, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, "IngParaAnticipo", "Ingreso computable para anticipo", "IngTotalIndependiente + IngTotalDependencia + IngOtros", 2, 0.0, 0.0, 14, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, "DeduccionTotalDeducir", "Importe a deducir", "(DeduccionSDmenores * 20 * BPC + DeduccionCD * 40 * BPC) / 12 + (DeduccionSDMenoresCincuenta * 20 * BPC + DeduccionCDCincuenta * 40 * BPC) * 0.5 / 12", 2, 0.0, 0.0, 15, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, "DeduccionFondoSolidaridad", "Deduccion de fondo de solidaridad", "CantidadBPCParaFS * BPC / 12", 2, 0.0, 0.0, 16, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, "DeduccionTotal", "Total de deducciones", "DeduccionTotalDeducir + DeduccionFondoSolidaridad + DeduccionFondoSolidaridadAdicional + DeduccionCJPPU + DeduccionJubilatorio + DeduccionFonasa + DeduccionFRL + DeduccionOtros", 2, 0.0, 0.0, 17, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, "DeduccionFondoSolidaridadAdicional", "Adicional fondo de solidaridad", "IIF(AdicionalFS = true,5/3 * BPC / 12, 0)", 2, 0.0, 0.0, 18, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, "AnticipoMensual", "Anticipo Mensual", "IIF(AnticipoNF = false, LiquidacionMes, LiquidacionMes * 0.95)", 2, 0.0, 0.0, 19, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, "TasaDeduccion", "Tasa liquidacion", "IIF(TotalExcedenteIngresos > (15 * BPC), 0.08, 0.10)", 2, 0.0, 0.0, 20, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "TotalExcedenteIngresos", "Ingresos exc. AG y SV", "IngParaAnticipo - IngIncrementoSeisPorciento - IngSalVacacional - DeduccionLegalIngresos", 2, 0.0, 0.0, 21, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, "TotalDeducible", "Total deducible para liquidacion", "DeduccionTotal * TasaDeduccion", 2, 0.0, 0.0, 22, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, "LiquidacionMes", "Liquidacion mes", "IIF((LiquidacionIngresos - TotalDeducible)>0,(LiquidacionIngresos -TotalDeducible),0)", 2, 0.0, 0.0, 23, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "HistorialParametros",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
