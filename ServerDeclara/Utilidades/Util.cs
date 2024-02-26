using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using System.Data;
using System.Reflection;

namespace ServerDeclara.Utilidades
{
    public class Util
    {
        public static Dictionary<string, double> ParamBPC_FS = new()
        {
            { "0 BPC" , 0 },
            { "1/2 BPC" , 0.5 },
            { "1 BPC" , 1 },
             { "2 BPC" , 2 },
        };

        public enum modoFormulario
        {
            EDICION,
            NUEVO,
            COPIA
        }

        public enum Operacion
        {
            OK,
            DUPLICADO,
            ADVERTENCIA,
            ERROR
        }

        public enum TipoIva
        {
            COMPRA,
            VENTA
        }

        public static DateTime UltimoDiaDelMes(DateTime fecha)  // Obtener el primer día del mes siguiente y restar un día
        {
            DateTime primerDiaDelMesSiguiente = new DateTime(fecha.Year, fecha.Month, 1).AddMonths(1);
            DateTime ultimoDiaDelMes = primerDiaDelMesSiguiente.AddDays(-1);

            return ultimoDiaDelMes;
        }

        public static DateTime PrimerDiaDelMes(DateTime fecha)  // Obtener el primer día del mes siguiente y restar un día
        {
            DateTime primerDiaDelMes = new DateTime(fecha.Year, fecha.Month, 1);
            return primerDiaDelMes;
        }

        public enum Vistas
        {
            GESTION_IVA,
            LISTADO_BIMENSUAL_IVA
        }

        public enum TipoListadoIRPF
        {
            RENTA,
            BPC,
            CALCULO
        }

        public static Dictionary<int, string> Mes = new Dictionary<int, string>()
        {
            {1,"Enero" }, {2,"Febrero"}, {3,"Marzo"}, {4,"Abril"}, {5,"Mayo"}, {6,"Junio"}, {7,"Julio"}, {8,"Agosto"}, {9,"Setiembre"}, {10,"Octubre"}, {11,"Noviembre"}, {12,"Diciembre"}
        };

    }
}
