using Categorias.Domain;
using Core.Result;

namespace Categorias.Application
{
    public class CrearCategoriasUseCase
    {
        private readonly ICategoriasManager _categoriasManager;

        public CrearCategoriasUseCase(ICategoriasManager categoriasManager)
        {
            _categoriasManager = categoriasManager;
        }

        public async Task<Result<List<Categoria>>> Execute(List<CrearCategoriaDto> dtos)
        {
            List<CrearCategoriaForm> forms = new();

            foreach (var dto in dtos)
            {
                var form = CrearForm(dto);
                forms.Add(form.Value);
            }

            return await _categoriasManager.CrearCategorias(forms);
        }

        private Result<CrearCategoriaForm> CrearForm(CrearCategoriaDto dto)
        {
            var nombreDeCategoriaResult = NombreDeCategoria.Create(dto.NombreDeCategoria);
            var subcategoriasFormsResult = CrearSubcategoriasForms(dto.Subcategorias);
            return Result<CrearCategoriaForm>.Success(new(nombreDeCategoriaResult.Value, subcategoriasFormsResult.Value));
        }


        private Result<List<CrearSubcategoriaForm>> CrearSubcategoriasForms(List<CrearSubcategoriaDto> dtos)
        {
            List<CrearSubcategoriaForm> forms = new();

            foreach (var dto in dtos)
            {
                forms.Add(CrearForm(dto).Value);
            }
            return Result<List<CrearSubcategoriaForm>>.Success(forms);
        }

        private Result<CrearSubcategoriaForm> CrearForm(CrearSubcategoriaDto dto)
        {

            var formResult = NombreDeCategoria.Create(dto.Nombre);
            var nombreCortoResult = NombreCortoDeSubcategoria.Create(dto.NombreCorto);
            var form = new CrearSubcategoriaForm(formResult.Value, nombreCortoResult.Value, dto.EsNSFW);
            return Result<CrearSubcategoriaForm>.Success(form);
        }
    }
}