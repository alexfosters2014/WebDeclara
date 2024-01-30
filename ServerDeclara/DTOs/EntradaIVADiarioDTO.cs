using ServerDeclara.Datos;

namespace ServerDeclara.DTOs
{
    public class EntradaIVADiarioDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public virtual ComercioDTO Comercio { get; set; } = new ComercioDTO();
        public double MontoTotal { get; set; }
        public double MontoMasIVA { get; set; }
        public double MontoIVA { get; set; }
        public double MontoIvaRetenido { get; set; }
        public string TipoIva { get; set; }  //Compra o Venta
        public string NombreArchivoPDF { get; set; } = string.Empty;
        public int EntradaIvaDiarioId { get; set; }
        public EntradaIVADiario EntradaIvaDiario { get; set; }
    }
}
