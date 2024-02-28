using Microsoft.AspNetCore.Components;
using ServerDeclara.DTOs;
using ServerDeclara.Servicios_de_datos;

namespace ServerDeclara.Servicios
{
    public class UsuarioServicio
    {
        private UsuarioDTO usuarioLogueado { get; set; }
        private readonly UsuarioRepositorio usuarioRepositorio;
        private readonly NavigationManager navigationManager;


        public UsuarioServicio(UsuarioRepositorio usuarioRepositorio, NavigationManager navigationManager)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.navigationManager = navigationManager;
        }

        public UsuarioDTO GetUsuarioLogueado()
        {
            if (usuarioLogueado == null)
            {
                navigationManager.NavigateTo("/");
            }
            return usuarioLogueado;
        }

        public async Task<bool> LoginRegistro(string email, string idGoogle, string idToken)
        {
            // llamar al repositorio para loguear o registrar automaticamente
            var usuario = new UsuarioDTO()
            {
                Email = email,
                IdGoogle = idGoogle,
                Token = idToken
            };

            usuarioLogueado = await usuarioRepositorio.GetUsuario(usuario);
            
            bool logueado = usuarioLogueado == null ? false : true;

            return logueado;

        }

    }

}
