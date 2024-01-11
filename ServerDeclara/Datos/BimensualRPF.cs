namespace ServerDeclara.Datos
{
    public class BimensualRPF
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
        public virtual DeclaracionMensualIRPF DeclaracionMes1 { get; set; } = new DeclaracionMensualIRPF();
        public virtual DeclaracionMensualIRPF DeclaracionMes2 { get; set; } = new DeclaracionMensualIRPF();

        public double AnticipoExcedente { get; set; } = 0;
        public double AnticipoBimestre { get; set; } = 0;
        public bool AnticipoNF_SI_NO { get; set; }
    }
}
