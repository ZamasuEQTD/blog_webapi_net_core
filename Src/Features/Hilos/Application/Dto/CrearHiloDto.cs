namespace Hilos.Application
{
    public record CrearHiloDto(string Usuario, string Titulo, string Descripcion, List<string>? Encuesta);
}