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
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
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
                name: "BimensualesRPFs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    DeclaracionMes1Id = table.Column<int>(type: "int", nullable: true),
                    DeclaracionMes2Id = table.Column<int>(type: "int", nullable: true),
                    AnticipoExcedente = table.Column<double>(type: "float", nullable: false),
                    AnticipoBimestre = table.Column<double>(type: "float", nullable: false),
                    AnticipoNF_SI_NO = table.Column<bool>(type: "bit", nullable: false)
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComercioId = table.Column<int>(type: "int", nullable: true),
                    MontoTotal = table.Column<double>(type: "float", nullable: false),
                    MontoMasIVA = table.Column<double>(type: "float", nullable: false),
                    MontoIVA = table.Column<double>(type: "float", nullable: false),
                    MontoIvaRetenido = table.Column<double>(type: "float", nullable: false),
                    NombreArchivoPDF = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasIVAsDiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntradasIVAsDiarios_Comercios_ComercioId",
                        column: x => x.ComercioId,
                        principalTable: "Comercios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntradasIVAsDiarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "Atributo", "Descripcion", "Formula", "IngresosDesde", "IngresosHasta", "Orden", "Tasa", "Tipo", "ValidezParametrosDesde", "ValidezParametrosHasta" },
                values: new object[,]
                {
                    { 1, "", "0 A 7 BPC", "", 0.0, 7.0, 1, 0.0, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", "7 A 10 BPC", "", 7.0, 10.0, 2, 0.10000000000000001, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", "10 A 15 BPC", "", 10.0, 15.0, 3, 0.14999999999999999, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", "15 A 30 BPC", "", 15.0, 30.0, 4, 0.23999999999999999, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", "30 A 50 BPC", "", 30.0, 50.0, 5, 0.25, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "", "50 A 75 BPC", "", 50.0, 75.0, 6, 0.27000000000000002, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "", "75 A 115 BPC", "", 75.0, 115.0, 7, 0.31, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "", "> BPC", "", 115.0, 20000.0, 8, 0.35999999999999999, "RENTA", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "", "BPC", "", 0.0, 0.0, 1, 5660.0, "BPC", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BimensualesRPFs_DeclaracionMes1Id",
                table: "BimensualesRPFs",
                column: "DeclaracionMes1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BimensualesRPFs_DeclaracionMes2Id",
                table: "BimensualesRPFs",
                column: "DeclaracionMes2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BimensualesRPFs_UsuarioId",
                table: "BimensualesRPFs",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comercios_UsuarioId",
                table: "Comercios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasIVAsDiarios_ComercioId",
                table: "EntradasIVAsDiarios",
                column: "ComercioId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasIVAsDiarios_UsuarioId",
                table: "EntradasIVAsDiarios",
                column: "UsuarioId");
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
                name: "Comercios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
