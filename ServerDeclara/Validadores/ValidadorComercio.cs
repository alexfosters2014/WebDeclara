using FluentValidation;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using ServerDeclara.Utilidades;

namespace ServerDeclara.Validadores
{
    public class ValidadorComercio : AbstractValidator<ComercioDTO>
    {
        private readonly DeclaraContext _db;
        public ValidadorComercio(DeclaraContext declaraContext)
        {
            _db = declaraContext;

            RuleFor(r => r.RazonSocial).NotEmpty();
            RuleFor(r => r.NombreFantasia).NotEmpty();
            RuleFor(r => r.RUT).Must(EsRut);
            RuleFor(r => r.Porcentaje).GreaterThanOrEqualTo(0);
            RuleFor(r => r.RUT).Must(NoEsRutDuplicado);

            bool EsRut(string rut)
            {
                bool resultado = rut.Length == 12 && rut.All(char.IsDigit);
                return resultado;
            }

            bool NoEsRutDuplicado(string rut)
            {
                var comercio = _db.Comercios.SingleOrDefault(s => s.RUT == rut);
                return comercio == null;
            }

        }
    }
}
