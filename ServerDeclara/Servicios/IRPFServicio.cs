using Microsoft.AspNetCore.Components;
using ServerDeclara.DTOs;
using ServerDeclara.Servicios_de_datos;

namespace ServerDeclara.Servicios
{
    public class IRPFServicio
    {
        private readonly IRPFRepositorio IRPFRepositorio;
        private readonly UsuarioServicio _usuarioServicio;

        public IRPFServicio(IRPFRepositorio iRPFRepositorio, UsuarioServicio usuarioServicio)
        {
            IRPFRepositorio = iRPFRepositorio;
            _usuarioServicio = usuarioServicio;
        }

        public async Task<List<BimensualIRPF_ViewList>> GetListado()
        {
            int usuarioId = _usuarioServicio.GetUsuarioLogueado().Id;

            var listado = await IRPFRepositorio.GetListadoBimensual(usuarioId);

            return listado;

        }
        public async Task<bool> CrearNuevaDeclaracion(BimensualIRPF_DTO bimensualDTO)
        {
            bimensualDTO.Usuario = _usuarioServicio.GetUsuarioLogueado();

            bool nuevo = await IRPFRepositorio.CrearNuevaDeclaracion(bimensualDTO);

            return nuevo;

        }


    }
}
