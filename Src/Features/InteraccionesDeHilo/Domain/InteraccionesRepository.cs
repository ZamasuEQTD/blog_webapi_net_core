using Core.Failures;
using Core.Result;
using Hilos.Domain;
using Users.Domain;

namespace InteraccionesDeHilo.Domain
{

    public interface IInteraccionesDeHiloRepository
    {
        public Task<Failure> Add(InteraccionDeHilo interaccion);
        public Task<InteraccionDeHilo?> GetInteraccionDeHiloPorUsuario(UserId user, HiloId hilo);
        public Task  Update(InteraccionDeHilo interaccion);
        public Task<List<UserId>> GetSeguidoresDeHilos(HiloId hiloId);
        public Task<List<HiloId>> GetHilosOcultosDeUsuario(UserId userId);
        public Task<List<HiloId>> GetHilosFavoritosDeUsuario(UserId userId);
        public Task<List<HiloId>> GetHilosSeguidosDeUsuario(UserId userId);
    }
}