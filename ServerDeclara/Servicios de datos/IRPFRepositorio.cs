using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using ServerDeclara.DTOs.Otros;

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
                catch (Exception)
                {
                    return false;
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



    }
}
