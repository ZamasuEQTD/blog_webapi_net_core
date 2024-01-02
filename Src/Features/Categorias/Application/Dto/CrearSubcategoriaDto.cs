using System.Security.Cryptography.X509Certificates;

namespace Categorias.Application
{
    public class CrearSubcategoriaDto
    {
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public bool EsNSFW { get; set; }


    }
}