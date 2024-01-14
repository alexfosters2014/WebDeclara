﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServerDeclara.Datos;

#nullable disable

namespace ServerDeclara.Migrations
{
    [DbContext(typeof(DeclaraContext))]
    partial class DeclaraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServerDeclara.Datos.BimensualRPF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AnticipoBimestre")
                        .HasColumnType("float");

                    b.Property<double>("AnticipoExcedente")
                        .HasColumnType("float");

                    b.Property<bool>("AnticipoNF_SI_NO")
                        .HasColumnType("bit");

                    b.Property<int?>("DeclaracionMes1Id")
                        .HasColumnType("int");

                    b.Property<int?>("DeclaracionMes2Id")
                        .HasColumnType("int");

                    b.Property<int>("HistorialParametroId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeclaracionMes1Id");

                    b.HasIndex("DeclaracionMes2Id");

                    b.HasIndex("HistorialParametroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("BimensualesRPFs");
                });

            modelBuilder.Entity("ServerDeclara.Datos.Comercio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreFantasia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Porcentaje")
                        .HasColumnType("float");

                    b.Property<string>("RUT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Suspendido")
                        .HasColumnType("bit");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Comercios");
                });

            modelBuilder.Entity("ServerDeclara.Datos.DeclaracionMensualIRPF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AdicionalFS")
                        .HasColumnType("bit");

                    b.Property<double>("AnticipoMensual")
                        .HasColumnType("float");

                    b.Property<double>("AnticipoRetenciones")
                        .HasColumnType("float");

                    b.Property<double>("Bpc")
                        .HasColumnType("float");

                    b.Property<double>("CantidadBPCParaFS")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionCD")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionCDCincuenta")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionCJPPU")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionFRL")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionFonasa")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionFondoSolidaridad")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionFondoSolidaridadAdicional")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionJubilatorio")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionLegalIngresos")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionOtros")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionSDMenoresCincuenta")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionSDmenores")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionTotal")
                        .HasColumnType("float");

                    b.Property<double>("DeduccionTotalDeducir")
                        .HasColumnType("float");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("IngDependenciaCess")
                        .HasColumnType("float");

                    b.Property<double>("IngDependenciaNoCess")
                        .HasColumnType("float");

                    b.Property<double>("IngIncrementoSeisPorciento")
                        .HasColumnType("float");

                    b.Property<int>("IngIndependiente")
                        .HasColumnType("int");

                    b.Property<double>("IngOtros")
                        .HasColumnType("float");

                    b.Property<double>("IngParaAnticipo")
                        .HasColumnType("float");

                    b.Property<double>("IngSalVacacional")
                        .HasColumnType("float");

                    b.Property<double>("IngTotalDependencia")
                        .HasColumnType("float");

                    b.Property<double>("IngTotalIndependiente")
                        .HasColumnType("float");

                    b.Property<double>("LiquidacionMes")
                        .HasColumnType("float");

                    b.Property<double>("TotalDeducciones")
                        .HasColumnType("float");

                    b.Property<double>("TotalExcedenteIngresos")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DeclaracionsMensualesIRPFs");
                });

            modelBuilder.Entity("ServerDeclara.Datos.EntradaIVADiario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComercioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("MontoIVA")
                        .HasColumnType("float");

                    b.Property<double>("MontoIvaRetenido")
                        .HasColumnType("float");

                    b.Property<double>("MontoMasIVA")
                        .HasColumnType("float");

                    b.Property<double>("MontoTotal")
                        .HasColumnType("float");

                    b.Property<string>("NombreArchivoPDF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComercioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("EntradasIVAsDiarios");
                });

            modelBuilder.Entity("ServerDeclara.Datos.HistorialParametro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HistorialParametros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Periodo enero-diciembre 2024",
                            Fecha = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ServerDeclara.Datos.Parametro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Atributo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Formula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HistorialParametroId")
                        .HasColumnType("int");

                    b.Property<double>("IngresosDesde")
                        .HasColumnType("float");

                    b.Property<double>("IngresosHasta")
                        .HasColumnType("float");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<double>("Tasa")
                        .HasColumnType("float");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidezParametrosDesde")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidezParametrosHasta")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HistorialParametroId");

                    b.ToTable("Parametros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Atributo = "",
                            Descripcion = "0 A 7 BPC",
                            Formula = "",
                            HistorialParametroId = 1,
                            IngresosDesde = 0.0,
                            IngresosHasta = 7.0,
                            Orden = 1,
                            Tasa = 0.0,
                            Tipo = "RENTA",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Atributo = "",
                            Descripcion = "7 A 10 BPC",
                            Formula = "",
                            HistorialParametroId = 1,
                            IngresosDesde = 7.0,
                            IngresosHasta = 10.0,
                            Orden = 2,
                            Tasa = 0.10000000000000001,
                            Tipo = "RENTA",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Atributo = "",
                            Descripcion = "10 A 15 BPC",
                            Formula = "",
                            HistorialParametroId = 1,
                            IngresosDesde = 10.0,
                            IngresosHasta = 15.0,
                            Orden = 3,
                            Tasa = 0.14999999999999999,
                            Tipo = "RENTA",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Atributo = "",
                            Descripcion = "15 A 30 BPC",
                            Formula = "",
                            HistorialParametroId = 1,
                            IngresosDesde = 15.0,
                            IngresosHasta = 30.0,
                            Orden = 4,
                            Tasa = 0.23999999999999999,
                            Tipo = "RENTA",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Atributo = "",
                            Descripcion = "30 A 50 BPC",
                            Formula = "",
                            HistorialParametroId = 1,
                            IngresosDesde = 30.0,
                            IngresosHasta = 50.0,
                            Orden = 5,
                            Tasa = 0.25,
                            Tipo = "RENTA",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Atributo = "",
                            Descripcion = "50 A 75 BPC",
                            Formula = "",
                            HistorialParametroId = 1,
                            IngresosDesde = 50.0,
                            IngresosHasta = 75.0,
                            Orden = 6,
                            Tasa = 0.27000000000000002,
                            Tipo = "RENTA",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            Atributo = "",
                            Descripcion = "75 A 115 BPC",
                            Formula = "",
                            HistorialParametroId = 1,
                            IngresosDesde = 75.0,
                            IngresosHasta = 115.0,
                            Orden = 7,
                            Tasa = 0.31,
                            Tipo = "RENTA",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Atributo = "",
                            Descripcion = "> BPC",
                            Formula = "",
                            HistorialParametroId = 1,
                            IngresosDesde = 115.0,
                            IngresosHasta = 20000.0,
                            Orden = 8,
                            Tasa = 0.35999999999999999,
                            Tipo = "RENTA",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            Atributo = "",
                            Descripcion = "BPC",
                            Formula = "",
                            HistorialParametroId = 1,
                            IngresosDesde = 0.0,
                            IngresosHasta = 0.0,
                            Orden = 9,
                            Tasa = 5660.0,
                            Tipo = "BPC",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            Atributo = "DeduccionLegalIngresos",
                            Descripcion = "Deducción legal 30%",
                            Formula = "IngIndependiente * -0.3",
                            HistorialParametroId = 1,
                            IngresosDesde = 0.0,
                            IngresosHasta = 0.0,
                            Orden = 10,
                            Tasa = 0.0,
                            Tipo = "CALCULO",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            Atributo = "IngTotalIndependiente",
                            Descripcion = "Total ingresos fuera de la relación de dependencia",
                            Formula = "IngIndependiente + DeduccionLegalIngresos",
                            HistorialParametroId = 1,
                            IngresosDesde = 0.0,
                            IngresosHasta = 0.0,
                            Orden = 11,
                            Tasa = 0.0,
                            Tipo = "CALCULO",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            Atributo = "IngIncrementoSeisPorciento",
                            Descripcion = "Incremento del 6%",
                            Formula = "",
                            HistorialParametroId = 1,
                            IngresosDesde = 0.0,
                            IngresosHasta = 0.0,
                            Orden = 12,
                            Tasa = 0.0,
                            Tipo = "CALCULO",
                            ValidezParametrosDesde = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ServerDeclara.Datos.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdGoogle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ServerDeclara.Datos.BimensualRPF", b =>
                {
                    b.HasOne("ServerDeclara.Datos.DeclaracionMensualIRPF", "DeclaracionMes1")
                        .WithMany()
                        .HasForeignKey("DeclaracionMes1Id");

                    b.HasOne("ServerDeclara.Datos.DeclaracionMensualIRPF", "DeclaracionMes2")
                        .WithMany()
                        .HasForeignKey("DeclaracionMes2Id");

                    b.HasOne("ServerDeclara.Datos.HistorialParametro", "HistorialParametro")
                        .WithMany()
                        .HasForeignKey("HistorialParametroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServerDeclara.Datos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("DeclaracionMes1");

                    b.Navigation("DeclaracionMes2");

                    b.Navigation("HistorialParametro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ServerDeclara.Datos.Comercio", b =>
                {
                    b.HasOne("ServerDeclara.Datos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ServerDeclara.Datos.EntradaIVADiario", b =>
                {
                    b.HasOne("ServerDeclara.Datos.Comercio", "Comercio")
                        .WithMany()
                        .HasForeignKey("ComercioId");

                    b.HasOne("ServerDeclara.Datos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Comercio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ServerDeclara.Datos.Parametro", b =>
                {
                    b.HasOne("ServerDeclara.Datos.HistorialParametro", "HistorialParametro")
                        .WithMany()
                        .HasForeignKey("HistorialParametroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HistorialParametro");
                });
#pragma warning restore 612, 618
        }
    }
}
