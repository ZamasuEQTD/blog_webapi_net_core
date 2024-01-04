using Hilos.Domain;
using InteraccionesDeHilo.Domain;
using Users.Domain;

namespace InteraccionesDeHilo.Application
{
    public class PonerHiloEnFavoritoUseCase
    {
        private readonly IInteraccionesDeHiloManager _interaccionesDeHiloManager;

        public PonerHiloEnFavoritoUseCase(IInteraccionesDeHiloManager  interaccionesDeHiloManager)
        {
            _interaccionesDeHiloManager = interaccionesDeHiloManager;
        }
        public async Task Execute(CambiarInteraccionDeHiloDto dto)
        {
            await _interaccionesDeHiloManager.CambiarInteracciones(new CrearInteraccionDeHiloForm(){
                HiloId = new HiloId(Guid.Parse(dto.HiloId)),
                UserId = new UserId(Guid.Parse(dto.UserId)),
                Favorito = true
            });
        }
    }
}