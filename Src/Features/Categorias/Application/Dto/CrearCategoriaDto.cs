namespace Categorias.Application
{
    public class CrearCategoriaDto
    {
        public string NombreDeCategoria {get;  set;}

        public List<CrearSubcategoriaDto> SubcategoriasDtos{get;  set;}

         
    }
}