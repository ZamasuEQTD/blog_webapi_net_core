namespace Categorias.Infraestructure
{
    public class GetCategoriaDto
    {
        public string Nombre {get;set;}
        public List<GetSubcategoriaDto> Subcategorias {get;set;}
    }
}