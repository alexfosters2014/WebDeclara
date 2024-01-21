using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerDeclara.Migrations
{
    /// <inheritdoc />
    public partial class IPRFDesdeHasta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.AddColumn<DateTime>(
                name: "Desde",
                table: "BimensualesRPFs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Hasta",
                table: "BimensualesRPFs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Orden",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 2,
                column: "Orden",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 3,
                column: "Orden",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 4,
                column: "Orden",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 5,
                column: "Orden",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Orden",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 7,
                column: "Orden",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 8,
                column: "Orden",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 16,
                column: "Formula",
                value: "CantidadBPCParaFS * BPC / 12");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desde",
                table: "BimensualesRPFs");

            migrationBuilder.DropColumn(
                name: "Hasta",
                table: "BimensualesRPFs");

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Orden",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 2,
                column: "Orden",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 3,
                column: "Orden",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 4,
                column: "Orden",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 5,
                column: "Orden",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Orden",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 7,
                column: "Orden",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 8,
                column: "Orden",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 16,
                column: "Formula",
                value: "CantidadBPCParaFS * BPC");

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "Atributo", "Descripcion", "Formula", "HistorialParametroId", "IngresosDesde", "IngresosHasta", "Orden", "Tasa", "Tipo", "ValidezParametrosDesde", "ValidezParametrosHasta" },
                values: new object[] { 24, "AdicionalFondoSolidaridad", "Valor adicional Fondo de solidaridad", "IIF(AdicionalFS = true, 786, 0)", 1, 0.0, 0.0, 24, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
