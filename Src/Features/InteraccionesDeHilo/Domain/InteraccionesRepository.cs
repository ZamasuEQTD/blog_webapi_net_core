using Core.Failures;
using Core.Result;
using Hilos.Domain;
using Users.Domain;

namespace InteraccionesDeHilo.Domain
{

    public interface IInteraccionesDeHiloRepository
    {
        public Task<Failure> Add(InteraccionDeHilo interaccion);
        public Task<Result<InteraccionDeHilo>> GetInteraccionDeHiloPorUsuario(UserId user, HiloId hilo);
        public Task<Failure> Update(InteraccionDeHilo interaccion);
        public Task<Result<List<UserId>>> GetSeguidoresDeHilos(HiloId hiloId);
        public Task<Result<List<HiloId>>> GetHilosOcultosDeUsuario(UserId userId);
        public Task<Result<List<HiloId>>> GetHilosFavoritosDeUsuario(UserId userId);
        public Task<Result<List<HiloId>>> GetHilosSeguidosDeUsuario(UserId userId);
    }
}