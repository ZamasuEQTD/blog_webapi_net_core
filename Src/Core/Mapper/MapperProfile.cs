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

            CreateMap<EncuestaOpcion, GetOpcionDeEncuestaDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre.Value))
            .ForMember(dest => dest.Votos, opt => opt.MapFrom(src => src.Votos.Value));

            CreateMap<MediaReference, GetImageResponse>()
            .ForMember(dest => dest.EsSpoiler, opt => opt.MapFrom(src => src.EsSpoiler))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Media.Hash + ".png"));

            CreateMap<Hilo, GetBanderasDeHiloResponse>()
            .ForMember(dest => dest.EsNuevo, opt => opt.MapFrom(src =>true))
            .ForMember(dest => dest.IdUnicoActivado, opt => opt.MapFrom(src =>src.Banderas.IdUnicoActivado))
            .ForMember(dest => dest.DadosActivado, opt => opt.MapFrom(src =>src.Banderas.DadosActivado))
            .ForMember(dest => dest.EncuestaActivada, opt => opt.MapFrom(src =>src.EncuestaId != null))
            .ForMember(dest => dest.StickyActivado, opt => opt.MapFrom(src =>true));

            CreateMap<Hilo, GetHiloResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Banderas, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo.Value))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion.Value))
            .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Subcategoria));

            CreateMap<Hilo, GetPortadaDeHiloResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Banderas, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Subcategoria.NombreCorto.Value))
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo.Value))
            .ForMember(dest => dest.Imagen, opt => opt.MapFrom(src=> src.Media))
            ;

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