namespace ServerDeclara.DTOs.Otros
{
    public class Periodo
    {
        public int UsuarioId { get; set; }
        public DateTime Desde { get; set; } = DateTime.Today;
        public DateTime Hasta { get; set; } = DateTime.Today;
    }
}
