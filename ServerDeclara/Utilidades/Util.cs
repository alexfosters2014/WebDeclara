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

      
    }
}
