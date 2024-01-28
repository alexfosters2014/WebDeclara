namespace ServerDeclara.DTOs
{
    public class BimensualIVA_ViewList
    {
        public int Id { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public double AnticipoBimestreIVA { get; set; } = 0;
    }
}
