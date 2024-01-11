using ServerDeclara.Datos;

namespace ServerDeclara.DTOs
{
    public class EntradaIVADiarioDTO
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
        public DateTime Fecha { get; set; }
        public virtual Comercio Comercio { get; set; } = new Comercio();
        public double MontoTotal { get; set; }
        public double MontoMasIVA { get; set; }
        public double MontoIVA { get; set; }
        public double MontoIvaRetenido { get; set; }
        public string NombreArchivoPDF { get; set; } = string.Empty;
    }
}
