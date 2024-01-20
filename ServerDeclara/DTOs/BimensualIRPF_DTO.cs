using ServerDeclara.Datos;
using ServerDeclara.Servicios;
using System.Data;
using System.Xml.Linq;

namespace ServerDeclara.DTOs
{
    public class BimensualIRPF_DTO
    {
        public int Id { get; set; }
        public UsuarioDTO Usuario { get; set; } = new UsuarioDTO();
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public virtual DeclaracionMensualIRPFDTO DeclaracionMes1 { get; set; } = new DeclaracionMensualIRPFDTO();
        public virtual DeclaracionMensualIRPFDTO DeclaracionMes2 { get; set; } = new DeclaracionMensualIRPFDTO();

        public double AnticipoExcedente { get; set; } = 0;
        public double AnticipoBimestre { get; set; } = 0;

        public bool AnticipoNF_SI_NO { get; set; } // NO-1 SI-0.95
        public int HistorialParametroId { get; set; }
        public HistorialParametroDTO HistorialParametro { get; set; }

        public List<ParametroDTO> GetParametros()
        {
            return HistorialParametro.Parametros;
        }

        public void CalcularAnticipoBimestre()
        {
            double anticipo = 0;

            anticipo += DeclaracionMes1.LiquidacionMes + DeclaracionMes2.LiquidacionMes;
            anticipo += DeclaracionMes1.AnticipoRetenciones + DeclaracionMes2.AnticipoRetenciones;
            anticipo += AnticipoExcedente;

            AnticipoBimestre = Math.Round(anticipo);
        }
       
    }

}
