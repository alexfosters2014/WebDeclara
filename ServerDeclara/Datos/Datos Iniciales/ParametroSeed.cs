using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerDeclara.Datos.Datos_Iniciales
{
    public class ParametroSeed : IEntityTypeConfiguration<Parametro>
    {
      
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
         
          builder.HasData(
              new Parametro()
              {
                  Id = 1,
                  Descripcion = "0 A 7 BPC",
                  ValidezParametrosDesde=new DateTime(2024,01,01),
                  ValidezParametrosHasta=new DateTime(2024, 12, 31),
                  Orden=3,
                  IngresosDesde=0,
                  IngresosHasta=7,
                  Tasa=0,
                  Atributo="",
                  Formula="",
                  Tipo="RENTA",
                  HistorialParametroId=1
              }, 
              new Parametro()
              {
                  Id = 2,
                  Descripcion = "7 A 10 BPC",
                  ValidezParametrosDesde = new DateTime(2024, 01, 01),
                  ValidezParametrosHasta = new DateTime(2024, 12, 31),
                  Orden = 6,
                  IngresosDesde = 7,
                  IngresosHasta = 10,
                  Tasa = 0.1,
                  Atributo = "",
                  Formula = "",
                  Tipo = "RENTA",
                  HistorialParametroId = 1
              },
               new Parametro()
               {
                   Id = 3,
                   Descripcion = "10 A 15 BPC",
                   ValidezParametrosDesde = new DateTime(2024, 01, 01),
                   ValidezParametrosHasta = new DateTime(2024, 12, 31),
                   Orden = 9,
                   IngresosDesde = 10,
                   IngresosHasta = 15,
                   Tasa = 0.15,
                   Atributo = "",
                   Formula = "",
                   Tipo = "RENTA",
                   HistorialParametroId = 1
               },
                 new Parametro()
                 {
                     Id = 4,
                     Descripcion = "15 A 30 BPC",
                     ValidezParametrosDesde = new DateTime(2024, 01, 01),
                     ValidezParametrosHasta = new DateTime(2024, 12, 31),
                     Orden = 12,
                     IngresosDesde = 15,
                     IngresosHasta = 30,
                     Tasa = 0.24,
                     Atributo = "",
                     Formula = "",
                     Tipo = "RENTA",
                     HistorialParametroId = 1
                 },
                   new Parametro()
                   {
                       Id = 5,
                       Descripcion = "30 A 50 BPC",
                       ValidezParametrosDesde = new DateTime(2024, 01, 01),
                       ValidezParametrosHasta = new DateTime(2024, 12, 31),
                       Orden = 15,
                       IngresosDesde = 30,
                       IngresosHasta = 50,
                       Tasa = 0.25,
                       Atributo = "",
                       Formula = "",
                       Tipo = "RENTA",
                       HistorialParametroId = 1
                   },
                     new Parametro()
                     {
                         Id = 6,
                         Descripcion = "50 A 75 BPC",
                         ValidezParametrosDesde = new DateTime(2024, 01, 01),
                         ValidezParametrosHasta = new DateTime(2024, 12, 31),
                         Orden = 18,
                         IngresosDesde = 50,
                         IngresosHasta = 75,
                         Tasa = 0.27,
                         Atributo = "",
                         Formula = "",
                         Tipo = "RENTA",
                         HistorialParametroId = 1
                     },
                      new Parametro()
                      {
                          Id = 7,
                          Descripcion = "75 A 115 BPC",
                          ValidezParametrosDesde = new DateTime(2024, 01, 01),
                          ValidezParametrosHasta = new DateTime(2024, 12, 31),
                          Orden = 21,
                          IngresosDesde = 75,
                          IngresosHasta = 115,
                          Tasa = 0.31,
                          Atributo = "",
                          Formula = "",
                          Tipo = "RENTA",
                          HistorialParametroId = 1
                      },

                       new Parametro()
                       {
                           Id = 8,
                           Descripcion = "> BPC",
                           ValidezParametrosDesde = new DateTime(2024, 01, 01),
                           ValidezParametrosHasta = new DateTime(2024, 12, 31),
                           Orden = 24,
                           IngresosDesde = 115,
                           IngresosHasta = 20000,
                           Tasa = 0.36,
                           Atributo = "",
                           Formula = "",
                           Tipo = "RENTA",
                           HistorialParametroId = 1
                       },
                        new Parametro()
                        {
                            Id = 9,
                            Descripcion = "BPC",
                            ValidezParametrosDesde = new DateTime(2024, 01, 01),
                            ValidezParametrosHasta = new DateTime(2024, 12, 31),
                            Orden = 9,
                            IngresosDesde = 0,
                            IngresosHasta = 0,
                            Tasa = 5660,
                            Atributo = "BPC",
                            Formula = "5660",
                            Tipo = "BPC",
                            HistorialParametroId = 1
                        },
                         new Parametro()
                         {
                             Id = 10,
                             Descripcion = "Deducción legal 30%",
                             ValidezParametrosDesde = new DateTime(2024, 01, 01),
                             ValidezParametrosHasta = new DateTime(2024, 12, 31),
                             Orden = 10,
                             IngresosDesde = 0,
                             IngresosHasta = 0,
                             Tasa = 0,
                             Atributo = "DeduccionLegalIngresos",
                             Formula = "IngIndependiente * -0.3",
                             Tipo = "CALCULO",
                             HistorialParametroId = 1
                         },
                            new Parametro()
                            {
                                Id = 11,
                                Descripcion = "Total ingresos fuera de la relación de dependencia",
                                ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                Orden = 11,
                                IngresosDesde = 0,
                                IngresosHasta = 0,
                                Tasa = 0,
                                Atributo = "IngTotalIndependiente",
                                Formula = "IngIndependiente + DeduccionLegalIngresos",
                                Tipo = "CALCULO",
                                HistorialParametroId = 1
                            },
                            new Parametro()
                            {
                                Id = 12,
                                Descripcion = "Incremento del 6%",
                                ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                Orden = 12,
                                IngresosDesde = 0,
                                IngresosHasta = 0,
                                Tasa = 0,
                                Atributo = "IngIncrementoSeisPorciento",
                                Formula = "IIF((IngDependenciaCess + IngDependenciaNoCess + IngSalVacacional) > (BPC * 10), IngDependenciaCess * 0.06, 0)",
                                Tipo = "CALCULO",
                                HistorialParametroId = 1
                            },
                              new Parametro()
                              {
                                  Id = 13,
                                  Descripcion = "Ingresos totales en realaciòn de dependencia",
                                  ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                  ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                  Orden = 13,
                                  IngresosDesde = 0,
                                  IngresosHasta = 0,
                                  Tasa = 0,
                                  Atributo = "IngTotalDependencia",
                                  Formula = "IngDependenciaCess + IngDependenciaNoCess + IngSalVacacional + IngIncrementoSeisPorciento",
                                  Tipo = "CALCULO",
                                  HistorialParametroId = 1
                              },
                              new Parametro()
                              {
                                  Id = 14,
                                  Descripcion = "Ingreso computable para anticipo",
                                  ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                  ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                  Orden = 14,
                                  IngresosDesde = 0,
                                  IngresosHasta = 0,
                                  Tasa = 0,
                                  Atributo = "IngParaAnticipo",
                                  Formula = "IngTotalIndependiente + IngTotalDependencia + IngOtros",
                                  Tipo = "CALCULO",
                                  HistorialParametroId = 1
                              },
                               new Parametro()
                               {
                                   Id = 15,
                                   Descripcion = "Importe a deducir",
                                   ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                   ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                   Orden = 15,
                                   IngresosDesde = 0,
                                   IngresosHasta = 0,
                                   Tasa = 0,
                                   Atributo = "DeduccionTotalDeducir",
                                   Formula = "(DeduccionSDmenores * 20 * BPC + DeduccionCD * 40 * BPC) / 12 + (DeduccionSDMenoresCincuenta * 20 * BPC + DeduccionCDCincuenta * 40 * BPC) * 0.5 / 12",
                                   Tipo = "CALCULO",
                                   HistorialParametroId = 1
                               },
                                new Parametro()
                                {
                                    Id = 16,
                                    Descripcion = "Deduccion de fondo de solidaridad",
                                    ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                    ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                    Orden = 16,
                                    IngresosDesde = 0,
                                    IngresosHasta = 0,
                                    Tasa = 0,
                                    Atributo = "DeduccionFondoSolidaridad",
                                    Formula = "CantidadBPCParaFS * BPC / 12",
                                    Tipo = "CALCULO",
                                    HistorialParametroId = 1
                                },
                                new Parametro()
                                {
                                    Id = 17,
                                    Descripcion = "Total de deducciones",
                                    ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                    ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                    Orden = 17,
                                    IngresosDesde = 0,
                                    IngresosHasta = 0,
                                    Tasa = 0,
                                    Atributo = "DeduccionTotal",
                                    Formula = "DeduccionTotalDeducir + DeduccionFondoSolidaridad + DeduccionFondoSolidaridadAdicional + DeduccionCJPPU + DeduccionJubilatorio + DeduccionFonasa + DeduccionFRL + DeduccionOtros",
                                    Tipo = "CALCULO",
                                    HistorialParametroId = 1
                                },
                                 new Parametro()
                                 {
                                     Id = 18,
                                     Descripcion = "Adicional fondo de solidaridad",
                                     ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                     ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                     Orden = 18,
                                     IngresosDesde = 0,
                                     IngresosHasta = 0,
                                     Tasa = 0,
                                     Atributo = "DeduccionFondoSolidaridadAdicional",
                                     Formula = "IIF(AdicionalFS = true,5/3 * BPC / 12, 0)",
                                     Tipo = "CALCULO",
                                     HistorialParametroId = 1
                                 },
                                  new Parametro()
                                  {
                                      Id = 19,
                                      Descripcion = "Anticipo Mensual",
                                      ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                      ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                      Orden = 19,
                                      IngresosDesde = 0,
                                      IngresosHasta = 0,
                                      Tasa = 0,
                                      Atributo = "AnticipoMensual",
                                      Formula = "IIF(AnticipoNF = false, LiquidacionMes, LiquidacionMes * 0.95)",
                                      Tipo = "CALCULO",
                                      HistorialParametroId = 1
                                  },
                                    new Parametro()
                                    {
                                        Id = 20,
                                        Descripcion = "Tasa liquidacion",
                                        ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                        ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                        Orden = 20,
                                        IngresosDesde = 0,
                                        IngresosHasta = 0,
                                        Tasa = 0,
                                        Atributo = "TasaDeduccion",
                                        Formula = "IIF(TotalExcedenteIngresos > (15 * BPC), 0.08, 0.14)",
                                        Tipo = "CALCULO",
                                        HistorialParametroId = 1
                                    },
                                      new Parametro()
                                      {
                                          Id = 21,
                                          Descripcion = "Ingresos exc. AG y SV",
                                          ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                          ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                          Orden = 21,
                                          IngresosDesde = 0,
                                          IngresosHasta = 0,
                                          Tasa = 0,
                                          Atributo = "TotalExcedenteIngresos",
                                          Formula = "IngParaAnticipo - IngIncrementoSeisPorciento - IngSalVacacional - DeduccionLegalIngresos",
                                          Tipo = "CALCULO",
                                          HistorialParametroId = 1
                                      },
                                        new Parametro()
                                        {
                                            Id = 22,
                                            Descripcion = "Total deducible para liquidacion",
                                            ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                            ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                            Orden = 22,
                                            IngresosDesde = 0,
                                            IngresosHasta = 0,
                                            Tasa = 0,
                                            Atributo = "TotalDeducible",
                                            Formula = "DeduccionTotal * TasaDeduccion",
                                            Tipo = "CALCULO",
                                            HistorialParametroId = 1
                                        },
                                         new Parametro()
                                         {
                                             Id = 23,
                                             Descripcion = "Liquidacion mes",
                                             ValidezParametrosDesde = new DateTime(2024, 01, 01),
                                             ValidezParametrosHasta = new DateTime(2024, 12, 31),
                                             Orden = 23,
                                             IngresosDesde = 0,
                                             IngresosHasta = 0,
                                             Tasa = 0,
                                             Atributo = "LiquidacionMes",
                                             Formula = "IIF((LiquidacionIngresos - TotalDeducible)>0,(LiquidacionIngresos -TotalDeducible),0)",
                                             Tipo = "CALCULO",
                                             HistorialParametroId = 1
                                         }



              );
        }
    }
}
