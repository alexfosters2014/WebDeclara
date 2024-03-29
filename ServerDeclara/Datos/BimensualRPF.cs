﻿namespace ServerDeclara.Datos
{
    public class BimensualRPF
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public virtual DeclaracionMensualIRPF DeclaracionMes1 { get; set; } = new DeclaracionMensualIRPF();
        public virtual DeclaracionMensualIRPF DeclaracionMes2 { get; set; } = new DeclaracionMensualIRPF();

        public double AnticipoExcedente { get; set; } = 0;
        public double AnticipoBimestre { get; set; } = 0;
        public bool AnticipoNF_SI_NO { get; set; }
        public int HistorialParametroId { get; set; }
        public HistorialParametro HistorialParametro { get; set; }
    }
}
