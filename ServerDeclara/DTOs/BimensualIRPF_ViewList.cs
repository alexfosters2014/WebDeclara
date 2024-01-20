namespace ServerDeclara.DTOs
{
    public class BimensualIRPF_ViewList
    {
        public int Id { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public double AnticipoBimestre { get; set; } = 0;
    }
}
