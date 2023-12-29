namespace Hilos.Application
{
    #pragma warning disable CS9113 // Parameter is unread.
    public sealed record  FiltrarPortadasDeHilosDto(int Pagina,List<string> HilosOcultados,List<string> CategoriasOcultadas,string? userId  = null,string? Categoria = null,string? Titulo  = null,DateTime? LimpiarBump = null);
}