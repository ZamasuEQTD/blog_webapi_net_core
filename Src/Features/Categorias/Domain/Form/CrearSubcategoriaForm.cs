namespace Categorias.Domain
{
    public class CrearSubcategoriaForm
    {
        public NombreDeCategoria Nombre { get; private set; }
        public NombreCortoDeSubcategoria NombreCorto { get; private set; }
        public bool EsNSFW { get; private set; }

        public CrearSubcategoriaForm(NombreDeCategoria nombre, NombreCortoDeSubcategoria nombreCorto, bool esNSFW)
        {
            Nombre = nombre;
            NombreCorto = nombreCorto;
            EsNSFW = esNSFW;
        }

    }
}