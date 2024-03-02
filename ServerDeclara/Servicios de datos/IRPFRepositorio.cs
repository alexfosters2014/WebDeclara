using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using ServerDeclara.DTOs.Otros;
using ServerDeclara.Utilidades;
using ServerDeclara.Validadores;

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
                    List<BimensualRPF> bimensual = await _db.BimensualesRPFs.Where(w => w.Usuario.Id == usuarioId)
                                                                            .OrderByDescending(o => o.Desde)
                                                                            .ToListAsync();

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
                ValidadorIRPF validador = new ValidadorIRPF(_db);
                ValidationResult resultado = validador.Validate(bimensualDTO);

                if (!resultado.IsValid)
                {
                    throw new Exception(string.Join(",", resultado.Errors.Select(e => e.ErrorMessage)));
                }


                if (bimensualDTO != null && await NoExisteDeclaracion(bimensualDTO))
                    {
                    //validar
                    Usuario usuarioBuscado = await _db.Usuarios.SingleOrDefaultAsync(s => s.Id == bimensualDTO.Usuario.Id);
                    HistorialParametro historialParametro = await _db.HistorialParametros.SingleOrDefaultAsync(s => s.Id == bimensualDTO.HistorialParametro.Id);
                    BimensualRPF bimensual = _mapper.Map<BimensualRPF>(bimensualDTO);

                    DateTime desde = bimensual.Desde;
                    DateTime hasta = bimensual.Hasta;
                    bimensual.Desde = Util.PrimerDiaDelMes(desde);
                    bimensual.Hasta = Util.UltimoDiaDelMes(hasta);
                    
                    bimensual.Usuario = usuarioBuscado;
                    bimensual.HistorialParametro = historialParametro;
                    bimensual.DeclaracionMes1.Fecha = bimensual.Desde;
                    bimensual.DeclaracionMes2.Fecha = bimensual.Hasta;

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
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

        public async Task<bool> EditarDeclaracion(BimensualIRPF_DTO bimensualDTO)
        {
            try
            {
                if (bimensualDTO != null)
                {
                    BimensualRPF bimensualNuevosDatos = _mapper.Map<BimensualRPF>(bimensualDTO);

                    BimensualRPF bimensualDatosAActualizar = await _db.BimensualesRPFs.Include(i => i.DeclaracionMes1)
                                                                                      .Include(i => i.DeclaracionMes2)
                                                                                      .Include(i => i.Usuario)
                                                                                      .Include(i => i.HistorialParametro.Parametros)
                                                                                      .SingleOrDefaultAsync(s => s.Id == bimensualNuevosDatos.Id);


                    bimensualDatosAActualizar.Desde = bimensualNuevosDatos.Desde;
                    bimensualDatosAActualizar.Hasta = bimensualNuevosDatos.Hasta;

                    DeclaracionlIRFTransitorio transitorioMes1 = _mapper.Map<DeclaracionlIRFTransitorio>(bimensualNuevosDatos.DeclaracionMes1);
                    bimensualDatosAActualizar.DeclaracionMes1 = _mapper.Map(transitorioMes1, bimensualDatosAActualizar.DeclaracionMes1);

                    DeclaracionlIRFTransitorio transitorioMes2 = _mapper.Map<DeclaracionlIRFTransitorio>(bimensualNuevosDatos.DeclaracionMes2);
                    bimensualDatosAActualizar.DeclaracionMes2 = _mapper.Map(transitorioMes2, bimensualDatosAActualizar.DeclaracionMes2);

                    bimensualDatosAActualizar.AnticipoBimestre = bimensualNuevosDatos.AnticipoBimestre;
                    bimensualDatosAActualizar.AnticipoExcedente = bimensualNuevosDatos.AnticipoExcedente;
                    bimensualDatosAActualizar.AnticipoNF_SI_NO = bimensualNuevosDatos.AnticipoNF_SI_NO;

                    if (bimensualDatosAActualizar.HistorialParametro.Id != bimensualNuevosDatos.HistorialParametro.Id)
                    {
                        bimensualDatosAActualizar.HistorialParametro = bimensualNuevosDatos.HistorialParametro;
                        _db.Entry(bimensualDatosAActualizar.HistorialParametro).State = EntityState.Unchanged;
                    }

                    if (bimensualDatosAActualizar.HistorialParametro.Id != bimensualNuevosDatos.HistorialParametro.Id)
                    {
                        bimensualDatosAActualizar.HistorialParametro = bimensualNuevosDatos.HistorialParametro;
                        _db.Entry(bimensualDatosAActualizar.HistorialParametro).State = EntityState.Unchanged;
                    }

                    int cantidadEditados = await _db.SaveChangesAsync();

                    return cantidadEditados > 0;
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

        public async Task<BimensualIRPF_DTO> ObtenerDeclaracionBimensual(int idBimensual)
        {
            var declaracion = await _db.BimensualesRPFs.AsNoTracking()
                                                        .Include(i => i.DeclaracionMes1)
                                                        .Include(i => i.DeclaracionMes2)
                                                        .Include(i => i.Usuario)
                                                        .Include(i => i.HistorialParametro.Parametros)
                                                        .SingleOrDefaultAsync(s => s.Id == idBimensual);

            BimensualIRPF_DTO declaracionDTO = _mapper.Map<BimensualIRPF_DTO>(declaracion);

            return declaracionDTO;
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

        public async Task<BimensualIRPF_DTO> CopiaDeclaracionBimensual(int idBimensual)
        {
            var declaracionACopiar = await _db.BimensualesRPFs.AsNoTracking()
                                                        .Include(i => i.DeclaracionMes1)
                                                        .Include(i => i.DeclaracionMes2)
                                                        .Include(i => i.Usuario)
                                                        .Include(i => i.HistorialParametro.Parametros)
                                                        .SingleOrDefaultAsync(s => s.Id == idBimensual);


            declaracionACopiar.Id = 0;
            declaracionACopiar.Desde = DateTime.MinValue;
            declaracionACopiar.Hasta = DateTime.MinValue;

            declaracionACopiar.DeclaracionMes1.Id = 0;
            declaracionACopiar.DeclaracionMes2.Id = 0;

            declaracionACopiar.Usuario = await _db.Usuarios.SingleOrDefaultAsync(s => s.Id == declaracionACopiar.Usuario.Id);
            declaracionACopiar.HistorialParametro = await _db.HistorialParametros.SingleOrDefaultAsync(s => s.Id == declaracionACopiar.HistorialParametro.Id);

            _db.Entry(declaracionACopiar.Usuario).State = EntityState.Unchanged;
            _db.Entry(declaracionACopiar.HistorialParametro).State = EntityState.Unchanged;

            var entidad = await _db.BimensualesRPFs.AddAsync(declaracionACopiar);

            await _db.SaveChangesAsync();

            BimensualIRPF_DTO declaracionDTO = _mapper.Map<BimensualIRPF_DTO>(entidad.Entity);

            return declaracionDTO;
        }




    }
}
