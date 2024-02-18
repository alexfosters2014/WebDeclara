namespace ServerDeclara.Datos
{
    public class EntradaIVADiario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public virtual Comercio Comercio { get; set; } = new Comercio();
        public string Comprobante { get; set; }
        public double MontoTotal { get; set; }
        public double MontoMasIVA { get; set; }
        public double MontoIVA { get; set; }
        public double MontoIvaRetenido { get; set; }
        public string TipoIva {  get; set; }  //Compra o Venta
        public string NombreArchivoPDF { get; set; } = string.Empty;
        public int BimensualIVAId { get; set; }
        public BimensualIVA BimensualIVA { get; set; }
    }
}
