namespace Categorias.Domain
{
    public class CrearCategoriaForm
    {
        public NombreDeCategoria Nombre { get; private set; }

        public List<CrearSubcategoriaForm> Subcategorias { get; private set; }

        public CrearCategoriaForm(NombreDeCategoria nombre, List<CrearSubcategoriaForm> subcategorias)
        {
            Nombre = nombre;
            Subcategorias = subcategorias;
        }
    }
}