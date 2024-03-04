namespace ServerDeclara.DTOs.Otros
{
    public class MensualIVA_Resumido
    {
        public string Bimestre { get; set; }
        public double IvaVenta { get; set; }
        public double IvaCompra { get; set; }
        public double IvaVentaRetenido { get; set; }
        public double AnticipoTotal { get; set; }
    }
}
