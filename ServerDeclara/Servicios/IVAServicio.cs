using ServerDeclara.DTOs;
using ServerDeclara.DTOs.Otros;
using ServerDeclara.Servicios_de_datos;

namespace ServerDeclara.Servicios
{
    public class IVAServicio
    {
        private readonly IVARepositorio IVARepositorio;
        private readonly UsuarioServicio _usuarioServicio;
        private int bimensualIdSeleccionado = 0;

        public IVAServicio(IVARepositorio iVARepositorio, UsuarioServicio usuarioServicio)
        {
            IVARepositorio = iVARepositorio;
            _usuarioServicio = usuarioServicio;
        }

        public void SetIdBimensual(int IdBimensual) => bimensualIdSeleccionado = IdBimensual;

        public int GetIdBimensual() => bimensualIdSeleccionado;

        public async Task<List<BimensualIVA_ViewList>> GetListado()
        {
            int usuarioId = _usuarioServicio.GetUsuarioLogueado().Id;

            var listado = await IVARepositorio.GetListadoBimensual(usuarioId);

            return listado;

        }

        public async Task<BimensualIVADTO> ObtenerDeclaracion()
        {
            if (bimensualIdSeleccionado == 0) return null;

            BimensualIVADTO declaracionDTO = await IVARepositorio.ObtenerDeclaracionBimensual(bimensualIdSeleccionado);

            return declaracionDTO;

        }

        public async Task<bool> CrearNuevaDeclaracion(Periodo periodo)
        {
            periodo.UsuarioId = _usuarioServicio.GetUsuarioLogueado().Id;

            bool nuevo = await IVARepositorio.CrearNuevaDeclaracion(periodo);

            return nuevo;

        }



    }
}
