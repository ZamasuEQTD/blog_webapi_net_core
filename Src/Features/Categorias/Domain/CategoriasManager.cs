using Core.Result;

namespace Categorias.Domain
{
    public interface ICategoriasManager
    {
        public Task<Result<List<Categoria>>> GetCategorias();
        public Task<Result<Subcategoria>> GetSubcategoria(SubcategoriaId id);
        public Task<Result<List<Categoria>>> CrearCategorias(List<CrearCategoriaForm> crearCategoriaForms);
    }

    public class CategoriasManager : ICategoriasManager
    {
        private readonly ICategoriasRepository _categoriasRepository;
        public CategoriasManager(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        public async Task<Result<List<Categoria>>> CrearCategorias(List<CrearCategoriaForm> crearCategoriaForms)
        {
            var categoriaId = CategoriaId.Nuevo();
            List<Categoria> categoriasNuevas = new();
            foreach (var form in crearCategoriaForms)
            {
                List<Subcategoria> subcategorias = CrearSubcategorias(form.Subcategorias, categoriaId);

                Categoria categoria = new Categoria(categoriaId, form.Nombre, subcategorias);

                categoriasNuevas.Add(categoria);
            }
            await _categoriasRepository.Add(categoriasNuevas);
            return Result<List<Categoria>>.Success(categoriasNuevas);
        }

        public async Task<Result<List<Categoria>>> GetCategorias()
        {
            List<Categoria> categorias = await _categoriasRepository.GetCategorias();
            return Result<List<Categoria>>.Success(categorias);
        }

        public async Task<Result<Subcategoria>> GetSubcategoria(SubcategoriaId id)
        {
            Subcategoria? subcategoria = await _categoriasRepository.GetSubcategoria(id);
            if (subcategoria is null)
            {
                return Result<Subcategoria>.Failure(SubcategoriaFailures.NoEncontrado);
            }
            return Result<Subcategoria>.Success(subcategoria);
        }


        private List<Subcategoria> CrearSubcategorias(List<CrearSubcategoriaForm> forms, CategoriaId categoriaId)
        {
            List<Subcategoria> subcategorias = new();
            foreach (var form in forms)
            {
                subcategorias.Add(new(SubcategoriaId.Nuevo(), categoriaId, form.Nombre, form.NombreCorto, form.EsNSFW));
            }
            return subcategorias;
        }
    }
}