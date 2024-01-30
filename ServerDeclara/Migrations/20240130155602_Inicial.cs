using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerDeclara.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeclaracionsMensualesIRPFs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IngIndependiente = table.Column<int>(type: "int", nullable: false),
                    DeduccionLegalIngresos = table.Column<double>(type: "float", nullable: false),
                    IngTotalIndependiente = table.Column<double>(type: "float", nullable: false),
                    IngDependenciaCess = table.Column<double>(type: "float", nullable: false),
                    IngDependenciaNoCess = table.Column<double>(type: "float", nullable: false),
                    IngSalVacacional = table.Column<double>(type: "float", nullable: false),
                    IngIncrementoSeisPorciento = table.Column<double>(type: "float", nullable: false),
                    IngTotalDependencia = table.Column<double>(type: "float", nullable: false),
                    IngOtros = table.Column<double>(type: "float", nullable: false),
                    IngParaAnticipo = table.Column<double>(type: "float", nullable: false),
                    DeduccionSDmenores = table.Column<double>(type: "float", nullable: false),
                    DeduccionCD = table.Column<double>(type: "float", nullable: false),
                    DeduccionSDMenoresCincuenta = table.Column<double>(type: "float", nullable: false),
                    DeduccionCDCincuenta = table.Column<double>(type: "float", nullable: false),
                    DeduccionTotalDeducir = table.Column<double>(type: "float", nullable: false),
                    DeduccionFondoSolidaridad = table.Column<double>(type: "float", nullable: false),
                    DeduccionFondoSolidaridadAdicional = table.Column<double>(type: "float", nullable: false),
                    AdicionalFS = table.Column<bool>(type: "bit", nullable: false),
                    CantidadBPCParaFS = table.Column<double>(type: "float", nullable: false),
                    DeduccionCJPPU = table.Column<double>(type: "float", nullable: false),
                    DeduccionJubilatorio = table.Column<double>(type: "float", nullable: false),
                    DeduccionFonasa = table.Column<double>(type: "float", nullable: false),
                    DeduccionFRL = table.Column<double>(type: "float", nullable: false),
                    DeduccionOtros = table.Column<double>(type: "float", nullable: false),
                    DeduccionTotal = table.Column<double>(type: "float", nullable: false),
                    AnticipoMensual = table.Column<double>(type: "float", nullable: false),
                    AnticipoRetenciones = table.Column<double>(type: "float", nullable: false),
                    TotalExcedenteIngresos = table.Column<double>(type: "float", nullable: false),
                    TotalDeducciones = table.Column<double>(type: "float", nullable: false),
                    Bpc = table.Column<double>(type: "float", nullable: false),
                    LiquidacionMes = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclaracionsMensualesIRPFs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistorialParametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialParametros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdGoogle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngresosDesde = table.Column<double>(type: "float", nullable: false),
                    IngresosHasta = table.Column<double>(type: "float", nullable: false),
                    Tasa = table.Column<double>(type: "float", nullable: false),
                    ValidezParametrosDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidezParametrosHasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Atributo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    HistorialParametroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parametros_HistorialParametros_HistorialParametroId",
                        column: x => x.HistorialParametroId,
                        principalTable: "HistorialParametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BimensualesIVA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Desde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnticipoBimestreIVA = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BimensualesIVA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BimensualesIVA_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BimensualesRPFs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Desde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeclaracionMes1Id = table.Column<int>(type: "int", nullable: true),
                    DeclaracionMes2Id = table.Column<int>(type: "int", nullable: true),
                    AnticipoExcedente = table.Column<double>(type: "float", nullable: false),
                    AnticipoBimestre = table.Column<double>(type: "float", nullable: false),
                    AnticipoNF_SI_NO = table.Column<bool>(type: "bit", nullable: false),
                    HistorialParametroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BimensualesRPFs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BimensualesRPFs_DeclaracionsMensualesIRPFs_DeclaracionMes1Id",
                        column: x => x.DeclaracionMes1Id,
                        principalTable: "DeclaracionsMensualesIRPFs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BimensualesRPFs_DeclaracionsMensualesIRPFs_DeclaracionMes2Id",
                        column: x => x.DeclaracionMes2Id,
                        principalTable: "DeclaracionsMensualesIRPFs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BimensualesRPFs_HistorialParametros_HistorialParametroId",
                        column: x => x.HistorialParametroId,
                        principalTable: "HistorialParametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BimensualesRPFs_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comercios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RUT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Porcentaje = table.Column<double>(type: "float", nullable: false),
                    Suspendido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comercios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comercios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntradasIVAsDiarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComercioId = table.Column<int>(type: "int", nullable: true),
                    MontoTotal = table.Column<double>(type: "float", nullable: false),
                    MontoMasIVA = table.Column<double>(type: "float", nullable: false),
                    MontoIVA = table.Column<double>(type: "float", nullable: false),
                    MontoIvaRetenido = table.Column<double>(type: "float", nullable: false),
                    TipoIva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreArchivoPDF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntradaIvaDiarioId = table.Column<int>(type: "int", nullable: true),
                    BimensualIVAId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasIVAsDiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntradasIVAsDiarios_BimensualesIVA_BimensualIVAId",
                        column: x => x.BimensualIVAId,
                        principalTable: "BimensualesIVA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntradasIVAsDiarios_Comercios_ComercioId",
                        column: x => x.ComercioId,
                        principalTable: "Comercios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntradasIVAsDiarios_EntradasIVAsDiarios_EntradaIvaDiarioId",
                        column: x => x.EntradaIvaDiarioId,
                        principalTable: "EntradasIVAsDiarios",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "HistorialParametros",
                columns: new[] { "Id", "Descripcion", "Fecha" },
                values: new object[,]
                {
                    { 1, "Periodo enero-diciembre 2024", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Periodo enero-diciembre 2023", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "Atributo", "Descripcion", "Formula", "HistorialParametroId", "IngresosDesde", "IngresosHasta", "Orden", "Tasa", "Tipo", "ValidezParametrosDesde", "ValidezParametrosHasta" },
                values: new object[,]
                {
                    { 1, "", "0 A 7 BPC", "", 1, 0.0, 7.0, 3, 0.0, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", "7 A 10 BPC", "", 1, 7.0, 10.0, 6, 0.10000000000000001, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", "10 A 15 BPC", "", 1, 10.0, 15.0, 9, 0.14999999999999999, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", "15 A 30 BPC", "", 1, 15.0, 30.0, 12, 0.23999999999999999, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", "30 A 50 BPC", "", 1, 30.0, 50.0, 15, 0.25, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "", "50 A 75 BPC", "", 1, 50.0, 75.0, 18, 0.27000000000000002, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "", "75 A 115 BPC", "", 1, 75.0, 115.0, 21, 0.31, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "", "> BPC", "", 1, 115.0, 20000.0, 24, 0.35999999999999999, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "BPC", "BPC", "5660", 1, 0.0, 0.0, 9, 5660.0, "BPC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "DeduccionLegalIngresos", "Deducción legal 30%", "IngIndependiente * -0.3", 1, 0.0, 0.0, 10, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "IngTotalIndependiente", "Total ingresos fuera de la relación de dependencia", "IngIndependiente + DeduccionLegalIngresos", 1, 0.0, 0.0, 11, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "IngIncrementoSeisPorciento", "Incremento del 6%", "IIF((IngDependenciaCess + IngDependenciaNoCess + IngSalVacacional) > (BPC * 10), IngDependenciaCess * 0.06, 0)", 1, 0.0, 0.0, 12, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "IngTotalDependencia", "Ingresos totales en realaciòn de dependencia", "IngDependenciaCess + IngDependenciaNoCess + IngSalVacacional + IngIncrementoSeisPorciento", 1, 0.0, 0.0, 13, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "IngParaAnticipo", "Ingreso computable para anticipo", "IngTotalIndependiente + IngTotalDependencia + IngOtros", 1, 0.0, 0.0, 14, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "DeduccionTotalDeducir", "Importe a deducir", "(DeduccionSDmenores * 20 * BPC + DeduccionCD * 40 * BPC) / 12 + (DeduccionSDMenoresCincuenta * 20 * BPC + DeduccionCDCincuenta * 40 * BPC) * 0.5 / 12", 1, 0.0, 0.0, 15, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "DeduccionFondoSolidaridad", "Deduccion de fondo de solidaridad", "CantidadBPCParaFS * BPC / 12", 1, 0.0, 0.0, 16, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "DeduccionTotal", "Total de deducciones", "DeduccionTotalDeducir + DeduccionFondoSolidaridad + DeduccionFondoSolidaridadAdicional + DeduccionCJPPU + DeduccionJubilatorio + DeduccionFonasa + DeduccionFRL + DeduccionOtros", 1, 0.0, 0.0, 17, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "DeduccionFondoSolidaridadAdicional", "Adicional fondo de solidaridad", "IIF(AdicionalFS = true,5/3 * BPC / 12, 0)", 1, 0.0, 0.0, 18, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "AnticipoMensual", "Anticipo Mensual", "IIF(AnticipoNF = false, LiquidacionMes, LiquidacionMes * 0.95)", 1, 0.0, 0.0, 19, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "TasaDeduccion", "Tasa liquidacion", "IIF(TotalExcedenteIngresos > (15 * BPC), 0.08, 0.14)", 1, 0.0, 0.0, 20, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "TotalExcedenteIngresos", "Ingresos exc. AG y SV", "IngParaAnticipo - IngIncrementoSeisPorciento - IngSalVacacional - DeduccionLegalIngresos", 1, 0.0, 0.0, 21, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "TotalDeducible", "Total deducible para liquidacion", "DeduccionTotal * TasaDeduccion", 1, 0.0, 0.0, 22, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "LiquidacionMes", "Liquidacion mes", "IIF((LiquidacionIngresos - TotalDeducible)>0,(LiquidacionIngresos -TotalDeducible),0)", 1, 0.0, 0.0, 23, 0.0, "CALCULO", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
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

            migrationBuilder.CreateIndex(
                name: "IX_BimensualesIVA_UsuarioId",
                table: "BimensualesIVA",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_BimensualesRPFs_DeclaracionMes1Id",
                table: "BimensualesRPFs",
                column: "DeclaracionMes1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BimensualesRPFs_DeclaracionMes2Id",
                table: "BimensualesRPFs",
                column: "DeclaracionMes2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BimensualesRPFs_HistorialParametroId",
                table: "BimensualesRPFs",
                column: "HistorialParametroId");

            migrationBuilder.CreateIndex(
                name: "IX_BimensualesRPFs_UsuarioId",
                table: "BimensualesRPFs",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comercios_UsuarioId",
                table: "Comercios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasIVAsDiarios_BimensualIVAId",
                table: "EntradasIVAsDiarios",
                column: "BimensualIVAId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasIVAsDiarios_ComercioId",
                table: "EntradasIVAsDiarios",
                column: "ComercioId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasIVAsDiarios_EntradaIvaDiarioId",
                table: "EntradasIVAsDiarios",
                column: "EntradaIvaDiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_HistorialParametroId",
                table: "Parametros",
                column: "HistorialParametroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BimensualesRPFs");

            migrationBuilder.DropTable(
                name: "EntradasIVAsDiarios");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "DeclaracionsMensualesIRPFs");

            migrationBuilder.DropTable(
                name: "BimensualesIVA");

            migrationBuilder.DropTable(
                name: "Comercios");

            migrationBuilder.DropTable(
                name: "HistorialParametros");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
