using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using ServerDeclara.DTOs.Otros;
using ServerDeclara.Utilidades;
using ServerDeclara.Validadores;

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
            try
            {
                var declaracion = await _db.BimensualesIVA.Include(i => i.Usuario)
                                                          .Include(i => i.EntradasIVADiarios).ThenInclude(t => t.Comercio)
                                                          .SingleOrDefaultAsync(s => s.Id == idBimensual);


                double valorAnticipoNuevo = ObtenerAnticipoBimensual(declaracion);
                if (valorAnticipoNuevo != declaracion.AnticipoBimestreIVA)
                {
                    declaracion.AnticipoBimestreIVA = valorAnticipoNuevo;
                await _db.SaveChangesAsync();
                }
                

                BimensualIVADTO declaracionDTO = _mapper.Map<BimensualIVADTO>(declaracion);

                return declaracionDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

        private double ObtenerAnticipoBimensual(BimensualIVA bimensual)
        {
            double anticipo = 0;
            var comprobantes = bimensual.EntradasIVADiarios;

            double totalCompra = comprobantes.Where(c => c.TipoIva == Util.TipoIva.COMPRA.ToString()).Sum(sum => sum.MontoIVA);
            double totalVenta = comprobantes.Where(c => c.TipoIva == Util.TipoIva.VENTA.ToString()).Sum(sum => sum.MontoIVA);
            double totalVentaRetenido = comprobantes.Where(c => c.TipoIva == Util.TipoIva.VENTA.ToString()).Sum(sum => sum.MontoIvaRetenido);

            anticipo = totalVenta - totalCompra - totalVentaRetenido;

            return anticipo;
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
                    BimensualIVA bimensual = await _db.BimensualesIVA.SingleOrDefaultAsync(w => w.Desde.Month == periodo.Desde.Month &&
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

       

        public async Task<bool> CrearEntradaComprobanteIVA(EntradaIVADiarioDTO entradaIVA)
        {
            try
            {
                ValidadorIVA validador = new ValidadorIVA(_db);
                ValidationResult resultado = await validador.ValidateAsync(entradaIVA);

                if (!resultado.IsValid)
                {
                    throw new Exception(string.Join(",", resultado.Errors.Select(e => e.ErrorMessage)));
                }

                EntradaIVADiario entradaNueva = _mapper.Map<EntradaIVADiario>(entradaIVA);

                var bimensual = await _db.BimensualesIVA.SingleOrDefaultAsync(s => s.Id == entradaNueva.BimensualIVAId);
                entradaNueva.BimensualIVA = bimensual;

                var comercio = await _db.Comercios.SingleOrDefaultAsync(s => s.Id == entradaNueva.Comercio.Id);
                entradaNueva.Comercio = comercio;

                _db.Entry(entradaNueva.BimensualIVA).State = EntityState.Unchanged;
                _db.Entry(entradaNueva.Comercio).State = EntityState.Unchanged;

                await _db.EntradasIVAsDiarios.AddAsync(entradaNueva);

                int cantidadNuevos = await _db.SaveChangesAsync();

                return cantidadNuevos > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<bool> BorrarComprobanteIVA(int ivaId)
        {
            try
            {
                var comprobante = await _db.EntradasIVAsDiarios.SingleOrDefaultAsync(s => s.Id == ivaId);
               
                _db.EntradasIVAsDiarios.Remove(comprobante);

                int cantidadNuevos = await _db.SaveChangesAsync();

                return cantidadNuevos > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<BimensualIVADTO>> GetListadosBimensualesHistorial(int usuarioId, int cantidadAniosHaciaAtras)
        {
            try
            {
                if (usuarioId > 0)
                {
                    List<BimensualIVA> bimensual = await _db.BimensualesIVA.Include(i => i.EntradasIVADiarios).ThenInclude(t => t.Comercio)
                                                                            .Where(w => w.Usuario.Id == usuarioId &&
                                                                                       w.Desde.Year >= (DateTime.Today.Year - cantidadAniosHaciaAtras))
                                                                            .OrderByDescending(o => o.Desde)
                                                                            .ToListAsync();

                    if (bimensual == null) return null;

                    List<BimensualIVADTO> bimensualResultado = _mapper.Map<List<BimensualIVADTO>>(bimensual);
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
