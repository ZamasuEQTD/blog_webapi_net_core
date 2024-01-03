using Core.Failures;
using Core.Result;

namespace Categorias.Domain
{
    public interface ICategoriasRepository
    {
        public Task Add(List<Categoria> categorias);
        public Task Add(Categoria categoria);
        public Task<List<Categoria>> GetCategorias();
        public Task<Subcategoria?> GetSubcategoria(SubcategoriaId id);
        public Task<List<Subcategoria>> GetSubcategoriasNSFW();

    }
}