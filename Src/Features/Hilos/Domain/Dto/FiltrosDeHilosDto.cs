using Categorias.Domain;
using Shared.Common.Domain;
using Users.Domain;

namespace Hilos.Domain
{
    public record GetHilosFilterDto
    {
        public Pagina Pagina { get; } = Pagina.Create(0).Value;
        public List<HiloId> HilosParaOcultar { get; } = new();
        public List<SubcategoriaId> CategoriasOcultas { get; } = new();
        public SubcategoriaId? Categoria { get; }
        public TituloDeHilo? Titulo { get; }

        public GetHilosFilterDto(
            Pagina pagina,
            List<HiloId>? hilosParaOcultar,
            List<SubcategoriaId>? categoriasOcultas,
            SubcategoriaId? categoria = null,
            TituloDeHilo? titulo = null
        )
        {
            Pagina = pagina;
            HilosParaOcultar = hilosParaOcultar;
            CategoriasOcultas = categoriasOcultas;
            Categoria = categoria;
            Titulo = titulo;
        }
    }
}