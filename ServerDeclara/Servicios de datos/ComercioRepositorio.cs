using AutoMapper;
using ServerDeclara.Datos;
using ServerDeclara.DTOs.Otros;
using ServerDeclara.DTOs;
using ServerDeclara.Utilidades;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Validadores;
using FluentValidation.Results;
using iText.Forms.Fields.Merging;

namespace ServerDeclara.Servicios_de_datos
{
    public class ComercioRepositorio
    {
        private readonly DeclaraContext _db;
        private readonly IMapper _mapper;

        public ComercioRepositorio(DeclaraContext db, IMapper mapper)
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
            try
            {
                var declaracion = await _db.BimensualesIVA.AsNoTracking()
                                                                       .Include(i => i.Usuario)
                                                                       .Include(i => i.EntradasIVADiarios)
                                                                       .SingleOrDefaultAsync(s => s.Id == idBimensual);

                BimensualIVADTO declaracionDTO = _mapper.Map<BimensualIVADTO>(declaracion);

                return declaracionDTO;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public async Task<ComercioDTO> NuevoComercio(ComercioDTO comercioDTO)
        {
            try
            {
                if (comercioDTO != null)
                {
                    //Validador
                    ValidadorComercio validador = new ValidadorComercio(_db);
                    ValidationResult resultado = validador.Validate(comercioDTO);

                    if (!resultado.IsValid)
                    {
                        throw new Exception(string.Join(",", resultado.Errors.Select(e => e.ErrorMessage)));
                    }

                    Comercio comercio = _mapper.Map<Comercio>(comercioDTO);

                    _db.Entry(comercio.Usuario).State = EntityState.Unchanged;

                    var nuevoComercio = await _db.Comercios.AddAsync(comercio);

                    int cantidadNuevos = await _db.SaveChangesAsync();

                    return _mapper.Map<ComercioDTO>(nuevoComercio.Entity);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<List<ComercioDTO>> GetComerciosPorUsuario(int usuarioId)
        {
            List<ComercioDTO> listado = new();

            var listadoBD = await _db.Comercios.Where(w => w.Usuario.Id == usuarioId && !w.Suspendido).ToListAsync();

            listado = _mapper.Map<List<ComercioDTO>>(listadoBD);

            return listado;
        }




        //public async Task<bool> ComercioDuplicado(string rut)
        //{
        //    try
        //    {
        //        bool resultado = false;
        //        if (!string.IsNullOrEmpty(rut))
        //        {
        //            var comercio = await _db.Comercios.SingleOrDefaultAsync(w => w.RUT == rut);

        //            if (comercio != null) resultado = true;

        //            return resultado;
        //        }
        //        else
        //        {
        //            return resultado;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}


    }
}
