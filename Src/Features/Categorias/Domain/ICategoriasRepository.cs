using Core.Failures;
using Core.Result;

namespace Categorias.Domain
{
    public interface ICategoriasRepository {
        public Task<Failure> Add(List<Categoria> categorias);
        public Task<Failure> Add(Categoria categoria);

        public Task<Result<List<Categoria>>>GetCategorias();
        public Task<Result<Subcategoria>> GetSubcategoria(SubcategoriaId id);
    }
}