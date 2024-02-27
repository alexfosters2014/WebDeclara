using ServerDeclara.DTOs;
using ServerDeclara.Servicios_de_datos;

namespace ServerDeclara.Servicios
{
    public class UsuarioServicio
    {
        private UsuarioDTO usuarioLogueado { get; set; }
        private readonly UsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio(UsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public UsuarioDTO GetUsuarioLogueado()
        {
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
