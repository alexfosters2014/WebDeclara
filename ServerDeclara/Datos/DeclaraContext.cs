using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos.Datos_Iniciales;

namespace ServerDeclara.Datos
{
    public class DeclaraContext : DbContext
    {
        public DeclaraContext(DbContextOptions<DeclaraContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HistorialParametroSeed());
            modelBuilder.ApplyConfiguration(new ParametroSeed());
        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HistorialParametro> HistorialParametros { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<EntradaIVADiario> EntradasIVAsDiarios { get; set; }
        public DbSet<DeclaracionMensualIRPF> DeclaracionsMensualesIRPFs { get; set; }
        public DbSet<Comercio> Comercios { get; set; }
        public DbSet<BimensualRPF> BimensualesRPFs { get; set; }
    }
}
