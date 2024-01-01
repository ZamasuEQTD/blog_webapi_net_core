namespace Categorias.Domain
{
    public class Categoria
    {
        public CategoriaId Id { get; private set; }
        public NombreDeCategoria Nombre { get; private set; }
        public List<Subcategoria> Subcategorias { get; private set; }
        private Categoria() { }
        public Categoria(CategoriaId id, NombreDeCategoria nombre, List<Subcategoria> subcategorias)
        {
            Id = id;
            Nombre = nombre;
            Subcategorias = subcategorias;
        }
    }
}