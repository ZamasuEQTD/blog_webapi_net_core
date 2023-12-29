using Shared.Archivos.Application;

namespace Hilos.Application
{
    public class PortadaDeHiloResponse
    {
        public required string Id {get;set;}
        public required string Titulo {get;set;}
        public required string  Categoria {get;set;}
        public required ImageResponse Imagen {get;set;}
        public required BanderasDeHiloResponse Banderas {get;set;}
    }
}