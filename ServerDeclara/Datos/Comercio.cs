namespace ServerDeclara.Datos
{
    public class Comercio
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
        public string RazonSocial { get; set; } = string.Empty;
        public string NombreFantasia { get; set; } = string.Empty;
        public string RUT { get; set; } = string.Empty;
        public double Porcentaje { get; set; }
        public bool Suspendido { get; set; }
    }
}
