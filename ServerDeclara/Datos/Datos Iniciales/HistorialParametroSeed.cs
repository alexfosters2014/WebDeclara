using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerDeclara.Datos.Datos_Iniciales
{
    public class HistorialParametroSeed : IEntityTypeConfiguration<HistorialParametro>
    {
        public void Configure(EntityTypeBuilder<HistorialParametro> builder)
        {
            builder.HasData(
                new HistorialParametro()
                {
                     Id = 1,
                     Fecha= new DateTime(2024,01,01),
                     Descripcion = "Periodo Enero-Diciembre 2023"
                },
                  new HistorialParametro()
                  {
                      Id = 2,
                      Fecha = new DateTime(2023, 01, 01),
                      Descripcion = "Periodo Enero-Diciembre 2024"
                  }
                );
        }
    }
}
