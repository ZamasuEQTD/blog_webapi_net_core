namespace Hilos.Infraestructure
{
    public class CrearHiloRequestDto
    {
        public string Usuario {get; set;}
        public string Titulo{get; set;}
        public string Descripcion {get; set;}
        public IFormFile Portada {get; set;}
    }
}