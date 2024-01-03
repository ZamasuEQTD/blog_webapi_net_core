namespace Hilos.Application
{
    public sealed record FiltrarPortadasDeHilosDto(int Pagina, List<string> CategoriasOcultadas, string? userId = null, string? Categoria = null, string? Titulo = null, DateTime? LimpiarBump = null);
}