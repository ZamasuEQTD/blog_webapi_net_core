using AutoMapper;
using Categorias.Domain;
using Categorias.Infraestructure;

namespace WebApp
{
    public class AutoMapperProfile : Profile {

        public AutoMapperProfile()
        {
            CreateMap<Categoria, GetCategoriaDto>().ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre.Value));
            CreateMap<Subcategoria, GetSubcategoriaDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre.Value));

        }
    }
}