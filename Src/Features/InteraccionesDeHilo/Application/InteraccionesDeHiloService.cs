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

        public async Task<Failure> OcultarHilo(CambiarInteraccionDeHiloDto dto)
        {
            return await _interaccionesDeHiloManager.CambiarInteracciones(new()
            {
                HiloId = new HiloId(Guid.Parse(dto.HiloId)),
                UserId = new(Guid.Parse(dto.UserId)),
                Ocultar = true
            });
        }

        public async Task<Failure> PonerHiloEnFavorito(CambiarInteraccionDeHiloDto dto)
        {
            return await _interaccionesDeHiloManager.CambiarInteracciones(new()
            {
                HiloId = new HiloId(Guid.Parse(dto.HiloId)),
                UserId = new(Guid.Parse(dto.UserId)),
                Favorito = true
            });
        }

        public async Task<Failure> SeguirHilo(CambiarInteraccionDeHiloDto dto)
        {
            return await _interaccionesDeHiloManager.CambiarInteracciones(new()
            {
                HiloId = new HiloId(Guid.Parse(dto.HiloId)),
                UserId = new(Guid.Parse(dto.UserId)),
                Seguir = true
            });
        }
    }
}