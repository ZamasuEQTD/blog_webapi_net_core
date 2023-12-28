using Core.Failures;
using Hilos.Domain;
using InteraccionesDeHilo.Domain;

namespace InteraccionesDeHilo.Application
{

    public interface IInteraccionesDeHiloService
    {
        public Task<Failure> OcultarHilo(CambiarInteraccionDeHiloDto dto);   
        public Task<Failure> SeguirHilo(CambiarInteraccionDeHiloDto dto);   
        public Task<Failure> PonerHiloEnFavorito(CambiarInteraccionDeHiloDto dto);   

    }
    public class InteraccionesDeHiloService : IInteraccionesDeHiloService
    {
        public IInteraccionesDeHiloManager _interaccionesDeHiloManager;

        public InteraccionesDeHiloService(IInteraccionesDeHiloManager interaccionesDeHiloManager)
        {
            _interaccionesDeHiloManager = interaccionesDeHiloManager;
        }

        public Task<Failure> OcultarHilo(CambiarInteraccionDeHiloDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Failure> PonerHiloEnFavorito(CambiarInteraccionDeHiloDto dto)
        {
            await _interaccionesDeHiloManager.CambiarInteracciones(new(){
                HiloId = new HiloId(Guid.Parse("")),
                UserId = new (Guid.Parse(dto.UserId)),
                Favorito = true
            });
            throw new NotImplementedException();
        }

        public Task<Failure> SeguirHilo(CambiarInteraccionDeHiloDto dto)
        {
            throw new NotImplementedException();
        }
    }
}