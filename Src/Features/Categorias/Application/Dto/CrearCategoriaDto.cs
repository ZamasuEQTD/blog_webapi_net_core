namespace Categorias.Application
{
    public class CrearCategoriaDto
    {
        public string NombreDeCategoria { get; set; }
        public List<CrearSubcategoriaDto> Subcategorias { get; set; }

    }
}