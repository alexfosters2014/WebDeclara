using ServerDeclara.DTOs;
using ServerDeclara.Servicios_de_datos;

namespace ServerDeclara.Servicios
{
    public class ParametroServicio
    {
        private List<HistorialParametroDTO> historialParametrosDTO { get; set; }
        private readonly ParametroRepositorio parametroRepositorio;
        private HistorialParametroDTO parametroSeleccionado { get; set; }

        public ParametroServicio(ParametroRepositorio parametroRepositorio)
        {
            this.parametroRepositorio = parametroRepositorio;
        }

        public List<HistorialParametroDTO> Get()
        {
            return historialParametrosDTO;
        }

        public HistorialParametroDTO GetParametroSeleccionado()
        {
            return parametroSeleccionado;
        }

        public async Task SetParametroSeleccionado(HistorialParametroDTO historialParam)
        {
            parametroSeleccionado = historialParam;
        }



        public async Task<List<HistorialParametroDTO>> GetHistorialParametros()
        {

            historialParametrosDTO = await parametroRepositorio.GetParametros();
            return historialParametrosDTO;
        }
    }
}
