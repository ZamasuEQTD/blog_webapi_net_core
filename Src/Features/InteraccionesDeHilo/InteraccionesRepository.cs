using Core.Failures;
using Core.Result;
using Hilos.Domain;
using Users.Domain;

namespace InteraccionesDeHilo.Domain
{

    public interface IInteraccionesDeHiloRepository {
        public Task<Failure> Add(InteraccionDeHilo interaccion);
        public Task<Result<InteraccionDeHilo>> GetInteraccionDeHiloPorUsuario(UserId user, HiloId hilo);
        
    }
}