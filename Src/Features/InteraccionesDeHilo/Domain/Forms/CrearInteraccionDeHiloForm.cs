using Hilos.Domain;
using Users.Domain;

namespace InteraccionesDeHilo.Domain
{
    public class CrearInteraccionDeHiloForm(HiloId hiloId, UserId userId, bool seguir , bool ocultar, bool favorito)
    {
        public HiloId HiloId { get; private set; } = hiloId;
        public UserId UserId { get; private set; } = userId;
        public bool Seguir { get; private set; } = seguir;
        public bool Ocultar { get; private set; } = ocultar;
        public bool Favorito { get; private set; } = favorito;
    }
}