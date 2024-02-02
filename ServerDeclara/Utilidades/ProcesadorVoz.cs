using ServerDeclara.DTOs;
using System.Linq;

namespace ServerDeclara.Utilidades
{
    public static class ProcesadorVoz
    {

        public static ComercioDTO BusquedaComercioPorRazonSocial(string razonSocial, List<ComercioDTO> comercios)
        {
            ComercioDTO comercioBuscado = null;
            razonSocial = razonSocial.ToLower();

            comercioBuscado = ProcesadorVoz.BusquedaContains(razonSocial,comercios);

            if (comercioBuscado != null) return comercioBuscado;

            comercioBuscado = ProcesadorVoz.BusquedaPorPalabras(razonSocial, comercios);

            if (comercioBuscado != null) return comercioBuscado;

            comercioBuscado = ProcesadorVoz.BusquedaLevenshtein(razonSocial, comercios);

            if (comercioBuscado != null) return comercioBuscado;

            return comercioBuscado;
        }

        private static ComercioDTO BusquedaContains(string razonSocial, List<ComercioDTO> comercios)
        {
            ComercioDTO comercioBuscado = null;
            string[] textoSplit = razonSocial.Split(" ");
            foreach (var comercio in comercios)

                for (int i = 0; i < textoSplit.Length; i++)
                {
                    bool similitud = comercio.RazonSocial.ToLower().Contains(textoSplit[i]);
                    if (similitud)
                    {
                        comercioBuscado = comercio;
                        return comercioBuscado;
                    }
                }
            return comercioBuscado;
        }


        private static ComercioDTO BusquedaPorPalabras(string razonSocial, List<ComercioDTO> comercios)
        {
            ComercioDTO comercioBuscado = null;
            string[] razonSocialSplit = razonSocial.Split(" ");

            foreach (var comercio in comercios)
            {
                string[] comercioSplit = comercio.RazonSocial.ToLower().Split(" ");

                if (CoincidenciasPalabras(razonSocialSplit,comercioSplit) > 0)
                {
                    comercioBuscado = comercio;
                    return comercioBuscado;
                }
            }

            return comercioBuscado;
        }

        private static int CoincidenciasPalabras(string[] comparador, string[] comercio)
        {
            int coincidencias = 0;
            List<string> listaDePalabras = new() { "de", "del", "el", "la", "las", "los" };

            for (int i = 0; i < comercio.Length; i++)
            {
                comercio[i] = comercio[i].Trim();
            }

            for (int i = 0; i < comparador.Length; i++)
            {
                comparador[i] = comparador[i].Trim();
            }

            for (int i = 0; i < comercio.Length; i++)
            {
                for (int j = 0; j < comparador.Length; i++)
                {
                    if (comercio[i] == comparador[j])
                    {
                        {
                            bool estaEnLaLista = listaDePalabras.Any(p => string.Equals(p, comercio[i], StringComparison.OrdinalIgnoreCase));

                            if (!estaEnLaLista)
                            {
                                coincidencias++;
                            }
                        }
                    }
                }
            }

            return coincidencias;
        }

        private static ComercioDTO BusquedaLevenshtein(string razonSocial, List<ComercioDTO> comercios)
        {
            //coincidencia <= 2 
            ComercioDTO comercioBuscado = null;


            return comercioBuscado;
        }


        public static DateTime ProcesarFechaPorVoz(string texto)
        {
            DateTime fecha = DateTime.MinValue;

            string textoSinEspacio = TextoSinEspacios(texto);

            if (textoSinEspacio.Length != 8 && !HaySoloNumeros(texto)) return fecha;

            string formatoEsperado = "ddMMyyyy";
            DateTime.TryParseExact(textoSinEspacio, formatoEsperado, null, System.Globalization.DateTimeStyles.None, out fecha);

            return fecha;
        }

        private static string TextoSinEspacios(string texto)
        {
            return texto.Replace(" ", "");
        }
        private static bool HaySoloNumeros(string texto)
        {
            return texto.All(char.IsNumber);
        }
    }
}
