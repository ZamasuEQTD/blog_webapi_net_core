namespace Categorias.Infraestructure
{

    public class GetSubcategoriaDto
    {
        public string  Id {get;set;}
        public string Nombre {get;set;}
        public string Image => "hola";
        public bool EsNSFW {get;set;}
    }   
}