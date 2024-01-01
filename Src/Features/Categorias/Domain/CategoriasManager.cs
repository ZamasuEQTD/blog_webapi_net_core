using Core.Result;

namespace Categorias.Domain
{
    public interface ICategoriasManager {
        public Task<Result<List<Categoria>>> GetCategorias();
        public Task<Result<Subcategoria>> GetSubcategoria(SubcategoriaId id);

    }

    public class CategoriasManager : ICategoriasManager
    {
        private readonly ICategoriasRepository _categoriasRepository;
        public CategoriasManager(ICategoriasRepository categoriasRepository)
        {
         _categoriasRepository = categoriasRepository;   
        }
        public Task<Result<List<Categoria>>> GetCategorias()
        {
            return _categoriasRepository.GetCategorias();
        }

        public Task<Result<Subcategoria>> GetSubcategoria(SubcategoriaId id)
        {
            return _categoriasRepository.GetSubcategoria(id);
        }
    }
}