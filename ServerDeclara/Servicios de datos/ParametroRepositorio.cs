using AutoMapper;
using iText.Commons.Actions.Contexts;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using ServerDeclara.DTOs.Otros;

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

        public async Task<bool> EditarParametro(HistorialParametroDTO historialParam)
        {
            try
            {
                //var historialParametro = _mapper.Map<HistorialParametro>(historialParam);

                var historialParamBD = await _db.HistorialParametros.Include(i => i.Parametros)
                                                                    .SingleOrDefaultAsync(s => s.Id == historialParam.Id);

                _mapper.Map(historialParam, historialParamBD);

                await _db.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

    }
}
