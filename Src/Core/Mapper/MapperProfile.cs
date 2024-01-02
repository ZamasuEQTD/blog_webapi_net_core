using AutoMapper;
using Categorias.Domain;
using Categorias.Infraestructure;
using Encuestas.Domain;
using Encuestas.Infraestructure;
using Hilos.Application;
using Hilos.Domain;
using Medias.Domain;
using Shared.Archivos.Application;

namespace WebApp
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Categoria, GetCategoriaDto>().ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre.Value));

            CreateMap<Subcategoria, GetSubcategoriaDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre.Value));

            CreateMap<Encuesta, GetEncuestaDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.VotosTotales, opt => opt.MapFrom(src => SumarVotos(src.Opciones)));

            CreateMap<EncuestaOpcion, GetSubcategoriaDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre.Value));

            CreateMap<MediaReference, GetImageResponse>()
            .ForMember(dest => dest.EsSpoiler, opt => opt.MapFrom(src => src.EsSpoiler))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Media.Hash + ".png"));


            CreateMap<Hilo, GetPortadaDeHiloResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Subcategoria.NombreCorto.Value))
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo.Value));

        }

        public int SumarVotos(List<EncuestaOpcion> opcions)
        {
            int votos = 0;

            foreach (var o in opcions)
            {
                votos = votos + o.Votos.Value;
            }
            return votos;
        }
    }
}