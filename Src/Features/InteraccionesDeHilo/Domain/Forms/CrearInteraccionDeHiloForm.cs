using Hilos.Domain;
using Users.Domain;

namespace InteraccionesDeHilo.Domain
{
    public class CrearInteraccionDeHiloForm 
    {
        public required HiloId HiloId { get; set;}  
        public required UserId UserId { get; set;}  
        public bool Seguir { get; set; } = false;
        public bool Ocultar { get;  set; } = false;
        public bool Favorito { get;set; } = false;
    }
}