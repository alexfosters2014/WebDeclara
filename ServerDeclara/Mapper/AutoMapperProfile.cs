using AutoMapper;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;
using ServerDeclara.DTOs.Otros;

namespace ServerDeclara.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BimensualRPF, BimensualIRPF_DTO>().ReverseMap();
            CreateMap<Comercio, ComercioDTO>().ReverseMap();
            CreateMap<DeclaracionMensualIRPF, DeclaracionMensualIRPFDTO>().ReverseMap();
            CreateMap<EntradaIVADiario, EntradaIVADiarioDTO>().ReverseMap();
            CreateMap<Parametro, ParametroDTO>().ReverseMap();
            CreateMap<HistorialParametro, HistorialParametroDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<BimensualIRPF_ViewList, BimensualRPF>().ReverseMap();
            CreateMap<BimensualIVA_ViewList, BimensualIVA>().ReverseMap();
            CreateMap<BimensualIVA, BimensualIVADTO>().ReverseMap();
            CreateMap<DeclaracionlIRFTransitorio, DeclaracionMensualIRPF>().ReverseMap();


        }
    }
}
