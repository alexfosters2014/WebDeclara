using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerDeclara.Migrations
{
    /// <inheritdoc />
    public partial class HistorialParametro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistorialParametroId",
                table: "Parametros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HistorialParametro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialParametro", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 1,
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 2,
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 3,
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 4,
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 5,
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 6,
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 7,
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 8,
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HistorialParametroId", "Orden" },
                values: new object[] { null, 9 });

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "Atributo", "Descripcion", "Formula", "HistorialParametroId", "IngresosDesde", "IngresosHasta", "Orden", "Tasa", "Tipo", "ValidezParametrosDesde", "ValidezParametrosHasta" },
                values: new object[,]
                {
                    { 10, "DeduccionLegalIngresos", "Deducción legal 30%", "IngIndependiente * -0.3", null, 0.0, 0.0, 10, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "IngTotalIndependiente", "Total ingresos fuera de la relación de dependencia", "IngIndependiente + DeduccionLegalIngresos", null, 0.0, 0.0, 11, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "IngIncrementoSeisPorciento", "Incremento del 6%", "", null, 0.0, 0.0, 12, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_HistorialParametroId",
                table: "Parametros",
                column: "HistorialParametroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parametros_HistorialParametro_HistorialParametroId",
                table: "Parametros",
                column: "HistorialParametroId",
                principalTable: "HistorialParametro",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parametros_HistorialParametro_HistorialParametroId",
                table: "Parametros");

            migrationBuilder.DropTable(
                name: "HistorialParametro");

            migrationBuilder.DropIndex(
                name: "IX_Parametros_HistorialParametroId",
                table: "Parametros");

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "HistorialParametroId",
                table: "Parametros");

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 9,
                column: "Orden",
                value: 1);
        }
    }
}
