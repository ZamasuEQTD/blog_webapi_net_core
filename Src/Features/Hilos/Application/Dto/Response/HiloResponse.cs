namespace Hilos.Application
{
    public class HiloResponse
    {
        public required string Id {get;set;}
        public required string Titulo {get;set;}
        public required string Descripcion {get;set;}
        public required DateTime CreatedAt {get;set;}
        public required BanderasDeHiloResponse Banderas {get;set;}
    }
}