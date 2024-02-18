using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServerDeclara.Datos.Datos_Iniciales
{
    public class UsuarioSeed : IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(
                new Usuario()
                {
                    Id = 1,
                    Email = "alexfosters2014@gmail.com",
                    IdGoogle= "123456"
                }
                );
        }
    }
}
