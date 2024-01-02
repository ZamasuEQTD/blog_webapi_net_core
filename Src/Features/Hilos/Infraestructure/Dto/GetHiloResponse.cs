namespace Hilos.Application
{
    public class GetHiloResponse
    {
        public required string Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descripcion { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required GetBanderasDeHiloResponse Banderas { get; set; }
    }
}