namespace Hilos.Application
{
    public record CrearHiloDto(string Usuario, string Titulo, string Descripcion, IFormFile PortadaFile, List<string>? Encuesta);
}