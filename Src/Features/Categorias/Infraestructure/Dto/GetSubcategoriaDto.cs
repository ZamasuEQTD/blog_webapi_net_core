namespace Categorias.Infraestructure
{

    public class GetSubcategoriaDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }

        public string Image => Id + ".png";
    }
}