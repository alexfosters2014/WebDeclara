using ServerDeclara.DTOs;
using System.Linq;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using OpenAI.Managers;
using OpenAI;
using Microsoft.AspNetCore.Components.Forms;

namespace ServerDeclara.Utilidades
{
    public static class ProcesadorVoz
    {

        public static async Task<ComercioDTO> BusquedaComercioPorRazonSocial(string razonSocial, List<ComercioDTO> comercios)
        {
            ComercioDTO comercioBuscado = null;
            razonSocial = razonSocial.ToLower();

            comercioBuscado = await BusquedaChatGPTComercio(razonSocial,comercios);

            if (comercioBuscado != null) return comercioBuscado;

            return comercioBuscado;
        }

        private static async Task<ComercioDTO> BusquedaChatGPTComercio(string razonSocial, List<ComercioDTO> comercios)
        {
            ComercioDTO comercioBuscado = null;
            string comercioStr = string.Empty;
            string apiKey = "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";

            string listaComerciosStr = comercios.Select(com => com.RazonSocial)
                                                .Aggregate((acumulado, valorActual) => acumulado + ", " + valorActual);

            

            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = apiKey,
            });



            string prompt = "del siguiente listado (" + listaComerciosStr + ") necesito saber "+
                            "que item es el mas parecido a al siguiente texto: "+ razonSocial +
                            ". devolveme el item de la lista anterior entre corchetes rectos";


            var completionResult = await openAiService.ChatCompletion.CreateCompletion(
                new ChatCompletionCreateRequest()
                {
                    Messages = new List<ChatMessage>()
                    {
                        ChatMessage.FromUser(prompt)
                    },
                    Model = Models.Gpt_3_5_Turbo_16k
                });

            if (completionResult.Successful) {
                string response = completionResult.Choices.First().Message.Content;

                string caracterInicio = "[";
                string caracterFin = "]";
                comercioStr = FiltrarRespuestaGPT(response, caracterInicio, caracterFin);
            }

            if (comercioStr != string.Empty)
            {
                comercioBuscado = BusquedaContains(comercioStr, comercios);
            }
            return comercioBuscado;
        }

        public static DateTime ProcesarFechaPorVoz(string texto)
        {
            DateTime fecha = DateTime.MinValue;

            string textoSinEspacio = TextoSinEspacios(texto);

            if (textoSinEspacio.Length != 8 && !HaySoloNumeros(textoSinEspacio)) return fecha;

            string formatoEsperado = "ddMMyyyy";
            DateTime.TryParseExact(textoSinEspacio, formatoEsperado, null, System.Globalization.DateTimeStyles.None, out fecha);

            return fecha;
        }

        public static double ProcesarValoresPorVoz(string texto)
        {
            string textoSinEspacio = TextoSinEspacios(texto);

            if (!HaySoloNumeros(texto)) return 0;

            try
            {
                double valorNumero = 0;
                double.TryParse(textoSinEspacio, out valorNumero);
                return valorNumero;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public static string ProcesarCompraVentaPorVoz(string texto)
        {
            string resultado = "";
            string textoSinEspacio = TextoSinEspacios(texto);
            string compra = "compras";
            string venta = "ventas";

            if (compra.ToLower().Contains(textoSinEspacio.ToLower()))
            {
                resultado = Util.TipoIva.COMPRA.ToString();
            }


            if (venta.Contains(textoSinEspacio))
            {
                resultado = Util.TipoIva.VENTA.ToString();
            }
            return resultado;
        }

        private static string TextoSinEspacios(string texto)
        {
            return texto.Replace(" ", "");
        }
        private static bool HaySoloNumeros(string texto)
        {
            return texto.All(char.IsNumber);
        }

        private static string FiltrarRespuestaGPT(string respuesta, string caracterInicio, string caracterFin)
        {
            string filtro = string.Empty;

            int indiceInicio = respuesta.IndexOf(caracterInicio);
            int indiceFin = respuesta.IndexOf(caracterFin);

            // Verificar si ambos corchetes están presentes en la cadena
            if (indiceInicio != -1 && indiceFin != -1 && indiceFin > indiceInicio)
            {
                // Extraer el valor entre corchetes utilizando Substring
                filtro = respuesta.Substring(indiceInicio + 1, indiceFin - indiceInicio - 1);
               
            }
            return filtro;
        }

        private static ComercioDTO BusquedaContains(string razonSocial, List<ComercioDTO> comercios)
        {
            ComercioDTO comercioBuscado = null;

            comercioBuscado = comercios.FirstOrDefault(f => f.RazonSocial.ToLower() == razonSocial.ToLower());
            return comercioBuscado;
        }
    }
}
