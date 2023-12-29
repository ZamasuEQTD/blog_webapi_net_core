namespace InteraccionesDeHilo.Application
{
    public class PonerHiloEnFavoritoUseCase
    {
        private readonly IInteraccionesDeHiloService _interaccionesDeHiloService;

        public PonerHiloEnFavoritoUseCase(IInteraccionesDeHiloService interaccionesDeHiloService)
        {
            _interaccionesDeHiloService = interaccionesDeHiloService;
        }
        public async Task Execute(CambiarInteraccionDeHiloDto dto)
        {
            await _interaccionesDeHiloService.PonerHiloEnFavorito(dto);
        }
    }
}