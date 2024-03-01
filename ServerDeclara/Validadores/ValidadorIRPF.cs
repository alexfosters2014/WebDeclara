using FluentValidation;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;

namespace ServerDeclara.Validadores
{
    public class ValidadorIRPF : AbstractValidator<BimensualIRPF_DTO>
    {
        private readonly DeclaraContext _db;

        public ValidadorIRPF(DeclaraContext db)
        {
            _db = db;
        }

        public ValidadorIRPF()
        {
            RuleFor(r => r.Desde).NotEmpty().NotNull();
            RuleFor(r => r.Hasta).NotEmpty().NotNull();
            RuleFor(r => r).MustAsync((bimensual, desde) => EsFechaValida(bimensual));

        }

        private async Task<bool> EsFechaValida(BimensualIRPF_DTO bimensual)
        {
           bool fechas = bimensual.Desde < bimensual.Hasta ? true : false;
            return fechas;
        }

            //RuleFor(r => r.MontoIvaRetenido).GreaterThanOrEqualTo(0);
            //RuleFor(r => r.MontoIVA).GreaterThanOrEqualTo(0);
            //RuleFor(r => r.MontoMasIVA).GreaterThanOrEqualTo(0);
            //RuleFor(r => r.MontoTotal).GreaterThanOrEqualTo(0);
            //RuleFor(r => r.Comercio).NotNull();
            //RuleFor(r => r.Fecha).NotNull().NotEmpty().Must(f => f > DateTime.MinValue);
            //RuleFor(r => r.TipoIva).NotEmpty().Must(tipoiva => tipoiva == Util.TipoIva.COMPRA.ToString() ||
            //                                                   tipoiva == Util.TipoIva.VENTA.ToString());
            //RuleFor(r => r.NombreArchivoPDF).NotEmpty().NotNull().Must(ContienePdf);
            //RuleFor(r => r.Comprobante).NotEmpty();
            //RuleFor(r => r.BimensualIVAId).GreaterThan(0).MustAsync(ExisteBimensual);

            //bool ContienePdf(string nombreArchivo)
            //{
            //    bool resultado = nombreArchivo.Contains(".pdf");
            //    return resultado;
            //}


    }
}
