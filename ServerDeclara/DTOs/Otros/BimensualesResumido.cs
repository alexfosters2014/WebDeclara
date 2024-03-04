namespace ServerDeclara.DTOs.Otros
{
    public class BimensualesResumido
    {
        public int Anio { get; set; }
        public List<BimensualIRPF_DTO> BimensualesIRPF { get; set; }
        public List<BimensualIVADTO> BimensualesIVA { get; set; }
    }
}
