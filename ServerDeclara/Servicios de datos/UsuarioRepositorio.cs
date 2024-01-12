using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;

namespace ServerDeclara.Servicios_de_datos
{
    public class UsuarioRepositorio
    {
        private readonly DeclaraContext _db;
        private readonly IMapper _mapper;

        public UsuarioRepositorio(DeclaraContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> GetUsuario(UsuarioDTO usuario)
        {
            try
            {
                if (ExisteUsuario(usuario.Email))
                {
                    Usuario usarioBuscado = await _db.Usuarios.SingleOrDefaultAsync(s => s.Email == usuario.Email && s.IdGoogle == usuario.IdGoogle);

                    if (usarioBuscado == null) return null;

                    UsuarioDTO usuarioLogueado = _mapper.Map<UsuarioDTO>(usarioBuscado);
                    return usuarioLogueado;
                }
                else
                {
                    return await RegistroUsuario(usuario);
                }
                
            }
            catch (Exception)
            {
                return null;
            }
           
        }
        public async Task<UsuarioDTO> RegistroUsuario(UsuarioDTO usuario)
        {
            try
            {

                Usuario usuarioRegistrar = _mapper.Map<Usuario>(usuario);

                await _db.Usuarios.AddAsync(usuarioRegistrar);
                await _db.SaveChangesAsync();

                UsuarioDTO usuarioLogueado = _mapper.Map<UsuarioDTO>(usuarioRegistrar);

                return usuarioLogueado;
            }
            catch (Exception)
            {
                return null;
            }

        }


        public bool ExisteUsuario(string mail)
        {
            try
            {
                bool usuarioBuscado = _db.Usuarios.Any(s => s.Email == mail);
                return usuarioBuscado;
            }
            catch (Exception)
            {
                return false;
            }

        }


    }
}
