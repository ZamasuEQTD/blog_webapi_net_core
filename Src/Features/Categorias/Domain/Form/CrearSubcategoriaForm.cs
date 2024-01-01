namespace Categorias.Domain
{
    public class CrearSubcategoriaForm
    {
        public NombreDeCategoria Nombre { get; private set; }
        public bool EsNSFW { get; private set; }

        public CrearSubcategoriaForm(NombreDeCategoria nombre, bool esNSFW)
        {
            Nombre = nombre;
            EsNSFW = esNSFW;
        }

    }
}