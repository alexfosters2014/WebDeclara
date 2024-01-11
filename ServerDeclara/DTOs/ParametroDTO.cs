namespace ServerDeclara.DTOs
{
    public class ParametroDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public double IngresosDesde { get; set; }
        public double IngresosHasta { get; set; }
        public double Tasa { get; set; }
        public DateTime ValidezParametrosDesde { get; set; }
        public DateTime ValidezParametrosHasta { get; set; }
        public string Atributo { get; set; }
        public string Formula { get; set; }
        public string Tipo { get; set; }
        public int Orden { get; set; }
    }
}
