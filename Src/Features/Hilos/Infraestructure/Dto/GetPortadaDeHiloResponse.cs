using Shared.Archivos.Application;

namespace Hilos.Application
{
    public class GetPortadaDeHiloResponse
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public GetImageResponse Imagen { get; set; }
        public GetBanderasDeHiloResponse Banderas { get; set; }
    }
}