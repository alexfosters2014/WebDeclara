using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using ServerDeclara.DTOs.Otros;
using ServerDeclara.Utilidades;

namespace ServerDeclara.Servicios_de_datos
{
    public class IVARepositorio
    {

        private readonly DeclaraContext _db;
        private readonly IMapper _mapper;

        public IVARepositorio(DeclaraContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<BimensualIVA_ViewList>> GetListadoBimensual(int usuarioId)
        {
            try
            {
                if (usuarioId > 0)
                {
                    List<BimensualIVA> bimensual = await _db.BimensualesIVA.Where(w => w.Usuario.Id == usuarioId)
                                                                            .OrderByDescending(o => o.Desde)
                                                                            .ToListAsync();

                    if (bimensual == null) return null;

                    List<BimensualIVA_ViewList> bimensualResultado = _mapper.Map<List<BimensualIVA_ViewList>>(bimensual);
                    return bimensualResultado;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<BimensualIVADTO> ObtenerDeclaracionBimensual(int idBimensual)
        {
            var declaracion = await _db.BimensualesIVA.AsNoTracking()
                                                        .Include(i => i.Usuario)
                                                        .Include(i => i.EntradasIVADiarios)
                                                        .SingleOrDefaultAsync(s => s.Id == idBimensual);

            BimensualIVADTO declaracionDTO = _mapper.Map<BimensualIVADTO>(declaracion);

            return declaracionDTO;
        }


        public async Task<bool> CrearNuevaDeclaracion(Periodo periodo)
        {
            try
            {
                if (periodo != null && await NoExisteDeclaracion(periodo))
                {
                    BimensualIVA bimensual = new();

                    Usuario usuarioBuscado = await _db.Usuarios.SingleOrDefaultAsync(s => s.Id == periodo.UsuarioId);
                  
                    DateTime desde = periodo.Desde;
                    DateTime hasta = periodo.Hasta;
                    bimensual.Desde = Util.PrimerDiaDelMes(desde);
                    bimensual.Hasta = Util.UltimoDiaDelMes(hasta);
                    bimensual.Usuario = usuarioBuscado;

                    //_db.Entry(bimensual.HistorialParametro).State = EntityState.Unchanged;

                    await _db.BimensualesIVA.AddAsync(bimensual);

                    int cantidadNuevos = await _db.SaveChangesAsync();

                    return cantidadNuevos > 0;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }




        public async Task<bool> NoExisteDeclaracion(Periodo periodo)
        {
            try
            {
                bool resultado = false;
                if (periodo != null)
                {
                    BimensualRPF bimensual = await _db.BimensualesRPFs.SingleOrDefaultAsync(w => w.Desde.Month == periodo.Desde.Month &&
                                                                                                 w.Desde.Year == periodo.Desde.Year &&
                                                                                                 w.Hasta.Month == periodo.Hasta.Month &&
                                                                                                 w.Hasta.Year == periodo.Hasta.Year &&
                                                                                                 w.Usuario.Id == periodo.UsuarioId);

                    if (bimensual == null) return true;

                    return resultado;
                }
                else
                {
                    return resultado;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }


    }
}
