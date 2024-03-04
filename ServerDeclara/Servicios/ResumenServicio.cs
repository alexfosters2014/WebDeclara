using ServerDeclara.DTOs;
using ServerDeclara.DTOs.Otros;
using ServerDeclara.Servicios_de_datos;
using System.Runtime.InteropServices;

namespace ServerDeclara.Servicios
{
    public class ResumenServicio
    {
        private readonly IRPFRepositorio _IRPFRepositorio;
        private readonly UsuarioServicio _usuarioServicio;
        private readonly IVARepositorio _IVARepositorio;

        

        public ResumenServicio(IRPFRepositorio iRPFRepositorio, UsuarioServicio usuarioServicio, IVARepositorio iVARepositorio)
        {
            _IRPFRepositorio = iRPFRepositorio;
            _usuarioServicio = usuarioServicio;
            _IVARepositorio = iVARepositorio;
        }

        public async Task<List<BimensualesResumido>> GetBimensualesResumido(int cantidadAniosAtrás)
        {
            try
            {
                int usuarioId = _usuarioServicio.GetUsuarioLogueado().Id;

                List<BimensualesResumido> resumenesAnuales = new();

                List<BimensualIRPF_DTO> resumenIRPFs = await _IRPFRepositorio.GetListadoBimensualHistorial(usuarioId, cantidadAniosAtrás);
                List<BimensualIVADTO> resumenIVAs = await _IVARepositorio.GetListadosBimensualesHistorial(usuarioId, cantidadAniosAtrás);

                if (resumenIRPFs == null || resumenIRPFs.Count == 0) resumenIRPFs = new();
                if (resumenIVAs == null || resumenIVAs.Count == 0) resumenIVAs = new();



                List<int> Anios = ObtenerAnios(resumenIRPFs, resumenIVAs);

                foreach (var anio in Anios)
                {
                    BimensualesResumido bim = new()
                    {
                        Anio = anio,
                        BimensualesIRPF = resumenIRPFs.Where(w => w.Desde.Year == anio).ToList(),
                        BimensualesIVA = resumenIVAs.Where(w => w.Desde.Year == anio).ToList()
                    };

                    resumenesAnuales.Add(bim);
                }

                return resumenesAnuales;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<int> ObtenerAnios(List<BimensualIRPF_DTO> resumenIRPFs, List<BimensualIVADTO> resumenIVAs)
        {
            var aniosIRPF = resumenIRPFs.Select(s => s.Desde.Year).ToList();
            var aniosIVA = resumenIVAs.Select(s => s.Desde.Year).ToList();

            var aniosUnicos = aniosIRPF.Union(aniosIVA)
                                       .Distinct()
                                       .OrderBy(o => o)
                                       .ToList();

            return aniosUnicos;
        }


    }
}
