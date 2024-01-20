using Microsoft.AspNetCore.Components;
using ServerDeclara.DTOs;
using ServerDeclara.Servicios_de_datos;

namespace ServerDeclara.Servicios
{
    public class IRPFServicio
    {
        private readonly IRPFRepositorio IRPFRepositorio;
        [Inject] UsuarioServicio _usuarioServicio {  get; set; }

        public IRPFServicio(IRPFRepositorio iRPFRepositorio)
        {
            IRPFRepositorio = iRPFRepositorio;
        }

        public async Task<List<BimensualIRPF_ViewList>> GetListado()
        {
            int usuarioId = _usuarioServicio.GetUsuarioLogueado().Id;

            var listado = await IRPFRepositorio.GetListadoBimensual(usuarioId);

            return listado;

        }
    }
}
