using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
            RuleFor(r => r).Must((bimensual, desde) => EsFechaValida(bimensual)).WithMessage("Los periodos de fechas no son correctos");
            RuleFor(r => r).MustAsync((bimensual, desde) => NoExistePeriodoDuplicado(bimensual)).WithMessage("Existe una duplicación de periodo");
            RuleFor(r => r).MustAsync((bimensual, desde) => ExisteSeleccionParametros(bimensual)).WithMessage("No elijió ningún parámetro");
            RuleFor(r => r).MustAsync((bimensual, desde) => ValidarDeclaraciones(bimensual)).WithMessage("Algunos datos están incorrector");

        }

        private bool EsFechaValida(BimensualIRPF_DTO bimensual)
        {
           bool fechas = bimensual.Desde < bimensual.Hasta ? true : false;
            return fechas;
        }

        private async Task<bool> NoExistePeriodoDuplicado(BimensualIRPF_DTO bimensual)
        {
            var existe = await _db.BimensualesRPFs.SingleOrDefaultAsync(s => s.Desde == bimensual.Desde && s.Hasta == bimensual.Hasta);
            return existe == null;
        }

        private async Task<bool> ExisteSeleccionParametros(BimensualIRPF_DTO bimensual)
        {
            return bimensual.HistorialParametro != null;
        }

        private async Task<bool> ValidarDeclaraciones(BimensualIRPF_DTO bimensual)
        {
            return true;
        }


    }
}
