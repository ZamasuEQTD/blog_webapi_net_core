using Hilos.Domain;
using Users.Domain;

namespace InteraccionesDeHilo.Domain
{
    public sealed class InteraccionDeHilo
    {
        public InteraccionDeHiloId Id { get; private set; }
        public UserId UserId { get; private set; }
        public User User { get; private set; }

        public HiloId HiloId { get; private set; }
        public Hilo Hilo { get; private set; }
        public bool Siguiendo { get; set; } = false;
        public bool Favorito { get; set; } = false;
        public bool Oculto { get; set; } = false;

        public InteraccionDeHilo(InteraccionDeHiloId id, UserId userId, HiloId hiloId)
        {
            Id = id;
            UserId = userId;
            HiloId = hiloId;
        }
        private InteraccionDeHilo() { }
    }
}