using AutoMapper;
using ServerDeclara.Datos;
using ServerDeclara.DTOs;

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
        }
    }
}
