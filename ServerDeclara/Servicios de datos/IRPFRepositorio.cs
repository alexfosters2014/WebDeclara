using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;

namespace ServerDeclara.Servicios_de_datos
{
    public class IRPFRepositorio
    {

        private readonly DeclaraContext _db;
        private readonly IMapper _mapper;

        public IRPFRepositorio(DeclaraContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<BimensualIRPF_ViewList>> GetListadoBimensual(int usuarioId)
        {
            try
            {
                if (usuarioId > 0)
                {
                    List<BimensualRPF> bimensual = await _db.BimensualesRPFs.Where(w => w.Usuario.Id == usuarioId).ToListAsync();

                    if (bimensual == null) return null;

                    List<BimensualIRPF_ViewList> bimensualResultado = _mapper.Map<List<BimensualIRPF_ViewList>>(bimensual);
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

            public async Task<bool> CrearNuevaDeclaracion(BimensualIRPF_DTO bimensualDTO)
            {
                try
                {
                    if (bimensualDTO != null && await NoExisteDeclaracion(bimensualDTO))
                    {
                    Usuario usuarioBuscado = await _db.Usuarios.SingleOrDefaultAsync(s => s.Id == bimensualDTO.Usuario.Id);
                    HistorialParametro historialParametro = await _db.HistorialParametros.SingleOrDefaultAsync(s => s.Id == bimensualDTO.HistorialParametro.Id);
                    BimensualRPF bimensual = _mapper.Map<BimensualRPF>(bimensualDTO);

                    
                    bimensual.Usuario = usuarioBuscado;
                    bimensual.HistorialParametro = historialParametro;
                    //_db.Entry(bimensual.HistorialParametro).State = EntityState.Unchanged;

                    await _db.BimensualesRPFs.AddAsync(bimensual);

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

        public async Task<bool> NoExisteDeclaracion(BimensualIRPF_DTO bimensualDTO)
        {
            try
            {
                bool resultado = false;
                if (bimensualDTO != null)
                {
                    BimensualRPF bimensual = await _db.BimensualesRPFs.SingleOrDefaultAsync(w => w.Desde.Month == bimensualDTO.Desde.Month && 
                                                                                                 w.Desde.Year == bimensualDTO.Desde.Year &&
                                                                                                 w.Hasta.Month == bimensualDTO.Hasta.Month &&
                                                                                                 w.Hasta.Year == bimensualDTO.Hasta.Year &&
                                                                                                 w.Usuario.Id == bimensualDTO.Usuario.Id);

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
