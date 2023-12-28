using Shared.Common.Domain;
using Users.Domain;

namespace Hilos.Domain
{
    public record GetHilosFilterDto
    {
        public Pagina Pagina { get; } = Pagina.Create(0).Value;
        public bool IgnorarEliminados { get; } = false;
        public List<string>? HilosParaOcultar { get; } 
        public List<string>? CategoriasOcultas { get; }
        public string? Categoria { get; }
        public string? Titulo { get; }

        public GetHilosFilterDto(
            Pagina pagina,
            bool ignorarEliminados,
            List<string>? hilosParaOcultar,
            List<string>? categoriasOcultas,
            string? categoria,
            string? titulo 
        )
        {
            Pagina = pagina;
            IgnorarEliminados = ignorarEliminados;
            HilosParaOcultar =  hilosParaOcultar;
            CategoriasOcultas = categoriasOcultas;
            Categoria = categoria;
            Titulo  = titulo;
        }
    }
}