using ServerDeclara.DTOs;
using ServerDeclara.Servicios_de_datos;

namespace ServerDeclara.Servicios
{
    public class ComercioServicio
    {
        private readonly ComercioRepositorio _comercioRepositorio;
        private readonly UsuarioServicio _usuarioServicio;

        public ComercioServicio(ComercioRepositorio comercioRepositorio, UsuarioServicio usuarioServicio)
        {
            _comercioRepositorio = comercioRepositorio;
            _usuarioServicio = usuarioServicio;
        }

        public async Task<List<ComercioDTO>> GetListadoComerciosPorUsuario()
        {
            try
            {
                int usuarioId = _usuarioServicio.GetUsuarioLogueado().Id;
                return await _comercioRepositorio.GetComerciosPorUsuario(usuarioId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> NuevoComercio(ComercioDTO comercio)
        {
            try
            {
                ComercioDTO nuevo = await _comercioRepositorio.NuevoComercio(comercio);
                return nuevo != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
