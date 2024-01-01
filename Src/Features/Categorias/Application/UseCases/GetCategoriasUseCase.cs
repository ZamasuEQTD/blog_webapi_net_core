using Categorias.Domain;
using Core.Result;

namespace Categorias.Application
{
    public class GetCategoriasUseCase
    {
        private readonly ICategoriasManager _categoriasManager;
        public GetCategoriasUseCase(ICategoriasManager categoriasManager)
        {
            _categoriasManager = categoriasManager;
        }
        public Task<Result<List<Categoria>>> Execute(){
           return _categoriasManager.GetCategorias();
        }
    }
}