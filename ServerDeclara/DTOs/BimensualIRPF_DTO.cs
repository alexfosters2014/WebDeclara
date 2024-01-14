using ServerDeclara.Datos;

namespace ServerDeclara.DTOs
{
    public class BimensualIRPF_DTO
    {
        public int Id { get; set; }
        public UsuarioDTO Usuario { get; set; } = new UsuarioDTO();
        public virtual DeclaracionMensualIRPFDTO DeclaracionMes1 { get; set; } = new DeclaracionMensualIRPFDTO();
        public virtual DeclaracionMensualIRPFDTO DeclaracionMes2 { get; set; } = new DeclaracionMensualIRPFDTO();

        public double AnticipoExcedente { get; set; } = 0;
        public double AnticipoBimestre { get; set; } = 0;

        public bool AnticipoNF_SI_NO { get; set; } // NO-1 SI-0.95
        public int HistorialParametroId { get; set; }
        public HistorialParametroDTO HistorialParametro { get; set; }

    }
}
