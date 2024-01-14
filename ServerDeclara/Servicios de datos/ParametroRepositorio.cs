using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;

namespace ServerDeclara.Servicios_de_datos
{
    public class ParametroRepositorio
    {
        private readonly DeclaraContext _db;
        private readonly IMapper _mapper;

        public ParametroRepositorio(DeclaraContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<HistorialParametroDTO>> GetParametros()
        {
            try
            {
                List<HistorialParametro> hParam = await _db.HistorialParametros.Include(i => i.Parametros).ToListAsync();
                return _mapper.Map<List<HistorialParametroDTO>>(hParam);

            }
            catch (Exception)
            {
                return null;
            }


       }

    }
}
