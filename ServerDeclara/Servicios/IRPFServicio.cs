using Microsoft.AspNetCore.Components;
using ServerDeclara.DTOs;
using ServerDeclara.Servicios_de_datos;

namespace ServerDeclara.Servicios
{
    public class IRPFServicio
    {
        private readonly IRPFRepositorio IRPFRepositorio;
        private readonly UsuarioServicio _usuarioServicio;
        private int bimensualIdSeleccionado = 0;

        public IRPFServicio(IRPFRepositorio iRPFRepositorio, UsuarioServicio usuarioServicio)
        {
            IRPFRepositorio = iRPFRepositorio;
            _usuarioServicio = usuarioServicio;
        }

        public void SetIdBimensual(int IdBimensual) => bimensualIdSeleccionado = IdBimensual;

        public int GetIdBimensual() => bimensualIdSeleccionado;

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

        public async Task<bool> EditarDeclaracion(BimensualIRPF_DTO bimensualDTO)
        {
            bool editado = await IRPFRepositorio.EditarDeclaracion(bimensualDTO);

            return editado;

        }

        public async Task<BimensualIRPF_DTO> ObtenerDeclaracion()
        {
            BimensualIRPF_DTO declaracionDTO = await IRPFRepositorio.ObtenerDeclaracionBimensual(bimensualIdSeleccionado);

            return declaracionDTO;

        }


    }
}
