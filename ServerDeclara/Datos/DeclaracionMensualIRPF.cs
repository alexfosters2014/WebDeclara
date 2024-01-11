namespace ServerDeclara.Datos
{
    public class DeclaracionMensualIRPF
    {
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int IngIndependiente { get; set; }
    public double DeduccionLegalIngresos { get; set; }
    public double IngTotalIndependiente { get; set; }
    public double IngDependenciaCess { get; set; }
    public double IngDependenciaNoCess { get; set; }
    public double IngSalVacacional { get; set; }
    public double IngIncrementoSeisPorciento { get; set; }
    public double IngTotalDependencia { get; set; }
    public double IngOtros { get; set; }
    public double IngParaAnticipo { get; set; }
    public double DeduccionSDmenores { get; set; }
    public double DeduccionCD { get; set; }
    public double DeduccionSDMenoresCincuenta { get; set; }
    public double DeduccionCDCincuenta { get; set; }
    public double DeduccionTotalDeducir { get; set; }
    public double DeduccionFondoSolidaridad { get; set; }
    public double DeduccionFondoSolidaridadAdicional { get; set; }
    public bool AdicionalFS { get; set; }
    public double CantidadBPCParaFS { get; set; }
    public double DeduccionCJPPU { get; set; }
    public double DeduccionJubilatorio { get; set; }
    public double DeduccionFonasa { get; set; }
    public double DeduccionFRL { get; set; }
    public double DeduccionOtros { get; set; }
    public double DeduccionTotal { get; set; }
    public double AnticipoMensual { get; set; }
    public double AnticipoRetenciones { get; set; }


    public double TotalExcedenteIngresos { get; set; }
    public double TotalDeducciones { get; set; }
    public double Bpc { get; set; }
    public double LiquidacionMes { get; set; }

    }
}
