namespace Categorias.Domain
{
    public class Subcategoria
    {
        public SubcategoriaId Id { get; private set; }
        public NombreDeCategoria Nombre { get; private set; }
        public bool EsNSFW { get; private set; }
        private Subcategoria() { }

        public Subcategoria(SubcategoriaId id, NombreDeCategoria nombre, bool esNSFW)
        {
            Id = id;
            Nombre = nombre;
            EsNSFW = esNSFW;
        }
    }
}