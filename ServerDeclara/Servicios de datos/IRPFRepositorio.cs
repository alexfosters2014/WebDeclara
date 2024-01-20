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
                if (usuarioId > 0 )
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
    }
}
