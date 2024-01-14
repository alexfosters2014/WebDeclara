using ServerDeclara.Datos;

namespace ServerDeclara.DTOs
{
    public class HistorialParametroDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public List<ParametroDTO> Parametros { get; set; }
    }
}
