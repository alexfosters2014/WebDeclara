using ServerDeclara.Datos;

namespace ServerDeclara.DTOs
{
    public class HistorialParametrosDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        List<ParametroDTO> Parametros { get; set; }
    }
}
