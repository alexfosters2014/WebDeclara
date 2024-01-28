using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;

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





    }
}
