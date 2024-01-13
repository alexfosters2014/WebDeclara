using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerDeclara.Migrations
{
    /// <inheritdoc />
    public partial class HistorialParametros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parametros_HistorialParametro_HistorialParametroId",
                table: "Parametros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistorialParametro",
                table: "HistorialParametro");

            migrationBuilder.RenameTable(
                name: "HistorialParametro",
                newName: "HistorialParametros");

            migrationBuilder.AlterColumn<int>(
                name: "HistorialParametroId",
                table: "Parametros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistorialParametros",
                table: "HistorialParametros",
                column: "Id");

            migrationBuilder.InsertData(
                table: "HistorialParametros",
                columns: new[] { "Id", "Descripcion", "Fecha" },
                values: new object[] { 1, "Periodo enero-diciembre 2024", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 1,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 2,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 3,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 4,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 5,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 6,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 7,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 8,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 9,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 10,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 11,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 12,
                column: "HistorialParametroId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Parametros_HistorialParametros_HistorialParametroId",
                table: "Parametros",
                column: "HistorialParametroId",
                principalTable: "HistorialParametros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parametros_HistorialParametros_HistorialParametroId",
                table: "Parametros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistorialParametros",
                table: "HistorialParametros");

            migrationBuilder.DeleteData(
                table: "HistorialParametros",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "HistorialParametros",
                newName: "HistorialParametro");

            migrationBuilder.AlterColumn<int>(
                name: "HistorialParametroId",
                table: "Parametros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistorialParametro",
                table: "HistorialParametro",
                column: "Id");

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
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 10,
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 11,
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 12,
                column: "HistorialParametroId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Parametros_HistorialParametro_HistorialParametroId",
                table: "Parametros",
                column: "HistorialParametroId",
                principalTable: "HistorialParametro",
                principalColumn: "Id");
        }
    }
}
