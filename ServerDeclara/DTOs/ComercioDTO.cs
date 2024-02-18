using ServerDeclara.Datos;

namespace ServerDeclara.DTOs
{
    public class ComercioDTO
    {
        public int Id { get; set; }
        public UsuarioDTO Usuario { get; set; } = new UsuarioDTO();
        public string RazonSocial { get; set; } = string.Empty;
        public string NombreFantasia { get; set; } = string.Empty;
        public string RUT { get; set; } = string.Empty;
        public double Porcentaje { get; set; }
        public bool Suspendido { get; set; }
    }
}
