using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using ServerDeclara.Utilidades;
using System.ComponentModel;
using System.Diagnostics;

namespace ServerDeclara.Validadores
{
    public class ValidadorIVA : AbstractValidator<EntradaIVADiarioDTO>
    {
        private readonly DeclaraContext _db;
        public ValidadorIVA(DeclaraContext db)
        {
            _db = db;

            RuleFor(r => r.MontoIvaRetenido).GreaterThanOrEqualTo(0);
            RuleFor(r => r.MontoIVA).GreaterThanOrEqualTo(0);
            RuleFor(r => r.MontoMasIVA).GreaterThanOrEqualTo(0);
            RuleFor(r => r.MontoTotal).GreaterThanOrEqualTo(0);
            RuleFor(r => r.Comercio).NotNull();
            RuleFor(r => r.Fecha).NotNull().NotEmpty().Must(f => f > DateTime.MinValue);
            RuleFor(r => r.TipoIva).NotEmpty().Must(tipoiva => tipoiva == Util.TipoIva.COMPRA.ToString() ||
                                                               tipoiva == Util.TipoIva.VENTA.ToString());
            RuleFor(r => r.NombreArchivoPDF).NotEmpty().NotNull().Must(ContienePdf);
            RuleFor(r => r.Comprobante).NotEmpty();
            RuleFor(r => r.BimensualIVAId).GreaterThan(0).MustAsync(ExisteBimensual);

            bool ContienePdf(string nombreArchivo)
            {
                bool resultado = nombreArchivo.Contains(".pdf");
                return resultado;
            }

        }

        async Task<bool> ExisteBimensual(int idBimensual, CancellationToken cancellationToken)
        {
            var bimensual = await _db.BimensualesIVA.SingleOrDefaultAsync(s => s.Id == idBimensual);
            return bimensual != null;
        }
    }
}
