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
                  Orden=1,
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
                  Orden = 2,
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
                   Orden = 3,
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
                     Orden = 4,
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
                       Orden = 5,
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
                         Orden = 6,
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
                          Orden = 7,
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
                           Orden = 8,
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
                            Atributo = "",
                            Formula = "",
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
                                Formula = "",
                                Tipo = "CALCULO",
                                HistorialParametroId = 1
                            }


              );
        }
    }
}
