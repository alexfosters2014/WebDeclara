namespace ServerDeclara.Datos
{
    public class HistorialParametro
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        List<Parametro> Parametros { get; set; }
    }
}
