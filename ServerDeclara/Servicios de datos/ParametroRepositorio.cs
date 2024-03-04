using AutoMapper;
using iText.Commons.Actions.Contexts;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using ServerDeclara.DTOs.Otros;
using ServerDeclara.Utilidades;

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
                List<HistorialParametro> hParam = await _db.HistorialParametros.Include(i => i.Parametros)
                                                                                .OrderByDescending(o => o.Fecha)
                                                                                .ToListAsync();
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

        public async Task<HistorialParametroDTO> CopiaParametro(HistorialParametroDTO historialParam, DataCopiaParametro paramCopia)
        {
            try
            {
                //var historialParametro = _mapper.Map<HistorialParametro>(historialParam);

                HistorialParametro historialParamBD = _mapper.Map<HistorialParametro>(historialParam);

                historialParamBD.Id = 0;
                historialParamBD.Fecha = DateTime.Now;
                historialParamBD.Descripcion = "Periodo " + Util.Mes[paramCopia.Inicio.Month] + "-" + Util.Mes[paramCopia.Fin.Month] + " " + paramCopia.Inicio.Year;
                historialParamBD.Parametros.ForEach(f => {
                    f.Id = 0;
                    f.ValidezParametrosDesde = paramCopia.Inicio;
                    f.ValidezParametrosHasta = paramCopia.Fin;
                });


                var entidad = await _db.AddAsync(historialParamBD);
                await _db.SaveChangesAsync();

                var copia = _mapper.Map<HistorialParametroDTO>(entidad.Entity);
                return copia;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


    }
}
