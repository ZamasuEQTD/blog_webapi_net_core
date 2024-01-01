using Categorias.Domain;

namespace Categorias.Application
{
    public class CrearCategoriasUseCase
    {
        private readonly ICategoriasManager _categoriasManager;

        public CrearCategoriasUseCase(ICategoriasManager categoriasManager)
        {
            _categoriasManager = categoriasManager;
        }

        public Task<List<Categoria>> Execute(List<CrearCategoriaDto> categoriaDtos)
        {
            throw new Exception("");
        }
    }
}