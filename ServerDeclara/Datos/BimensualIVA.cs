namespace ServerDeclara.Datos
{
    public class BimensualIVA
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }

        public double AnticipoBimestreIVA { get; set; }
        public List<EntradaIVADiario> EntradasIVADiarios { get; set; }
    }
}
