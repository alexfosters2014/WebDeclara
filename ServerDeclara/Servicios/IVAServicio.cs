using ServerDeclara.DTOs;
using ServerDeclara.DTOs.Otros;
using ServerDeclara.Servicios_de_datos;

namespace ServerDeclara.Servicios
{
    public class IVAServicio
    {
        private readonly IVARepositorio _IVARepositorio;
        private readonly UsuarioServicio _usuarioServicio;
        private readonly BlobAzureServicio _blobAzureServicio;
        private int bimensualIdSeleccionado = 0;

        public IVAServicio(IVARepositorio iVARepositorio, UsuarioServicio usuarioServicio, BlobAzureServicio blobAzureServicio)
        {
            _IVARepositorio = iVARepositorio;
            _usuarioServicio = usuarioServicio;
            _blobAzureServicio = blobAzureServicio;
        }

        public void SetIdBimensual(int IdBimensual) => bimensualIdSeleccionado = IdBimensual;

        public int GetIdBimensual() => bimensualIdSeleccionado;

        public async Task<List<BimensualIVA_ViewList>> GetListado()
        {
            int usuarioId = _usuarioServicio.GetUsuarioLogueado().Id;

            var listado = await _IVARepositorio.GetListadoBimensual(usuarioId);

            return listado;

        }

        public async Task<BimensualIVADTO> ObtenerDeclaracion()
        {
            if (bimensualIdSeleccionado == 0) return null;

            BimensualIVADTO declaracionDTO = await _IVARepositorio.ObtenerDeclaracionBimensual(bimensualIdSeleccionado);

            return declaracionDTO;

        }

        public async Task<bool> CrearNuevaDeclaracion(Periodo periodo)
        {
            periodo.UsuarioId = _usuarioServicio.GetUsuarioLogueado().Id;

            bool nuevo = await _IVARepositorio.CrearNuevaDeclaracion(periodo);

            return nuevo;

        }


        public async Task<bool> CrearNuevoComprobanteIVA(EntradaIVADiarioDTO comprobante)
        {
            try
            {
                bool nuevo = await _IVARepositorio.CrearEntradaComprobanteIVA(comprobante);

                return nuevo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           

        }

        public async Task<bool> BorrarComprobanteIVA(int ivaId, string nombreArchivo)
        {
            try
            {
                bool borrado = await _IVARepositorio.BorrarComprobanteIVA(ivaId);
                bool borradoImagen = await _blobAzureServicio.BorrarImagen(nombreArchivo);
                return borrado && borradoImagen;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }



    }
}
