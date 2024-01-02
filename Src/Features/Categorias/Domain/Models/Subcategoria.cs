namespace Categorias.Domain
{
    public class Subcategoria
    {
        public SubcategoriaId Id { get; private set; }
        public CategoriaId CategoriaId { get; private set; }
        public NombreDeCategoria Nombre { get; private set; }
        public bool EsNSFW { get; private set; }
        private Subcategoria() { }

        public Subcategoria(SubcategoriaId id,CategoriaId categoriaId, NombreDeCategoria nombre, bool esNSFW)
        {
            Id = id;
            CategoriaId = categoriaId;
            Nombre = nombre;
            EsNSFW = esNSFW;
        }
    }
}