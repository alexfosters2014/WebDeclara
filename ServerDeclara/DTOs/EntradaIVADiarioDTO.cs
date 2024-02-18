using ServerDeclara.Datos;

namespace ServerDeclara.DTOs
{
    public class EntradaIVADiarioDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public virtual ComercioDTO Comercio { get; set; } = new ComercioDTO();
        public string Comprobante { get; set; }
        public double MontoTotal { get; set; }
        public double MontoMasIVA { get; set; }
        public double MontoIVA { get; set; }
        public double MontoIvaRetenido { get; set; }
        public string TipoIva { get; set; }
        public string NombreArchivoPDF { get; set; } = string.Empty;
        public int BimensualIVAId { get; set; }
        public BimensualIVA BimensualIVA { get; set; }

    }
}
