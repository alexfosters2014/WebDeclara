using ServerDeclara.DTOs;
using ServerDeclara.DTOs.Otros;
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

        public async Task<bool> EditarParametros(HistorialParametroDTO historialParam)
        {

            try
            {
                bool actualizado = await parametroRepositorio.EditarParametro(historialParam);
                return actualizado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<HistorialParametroDTO> CopiaParametros(HistorialParametroDTO historialParam, DataCopiaParametro paramCopia)
        {

            try
            {
                var copiaRealizada = await parametroRepositorio.CopiaParametro(historialParam, paramCopia);
                return copiaRealizada;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }




    }
}
