namespace Hilos.Application
{
    public sealed record GetHiloDto(string HiloId, string? Usuario = null);
}