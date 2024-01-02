namespace Hilos.Application
{
    public record CrearHiloDto(
    string Categoria,
    string Usuario,
    string Titulo,
    string Descripcion,
    IFormFile PortadaFile,
    bool DadosActivado,
    bool IdUnicoActivado,
    List<string>? Encuesta
    );
}