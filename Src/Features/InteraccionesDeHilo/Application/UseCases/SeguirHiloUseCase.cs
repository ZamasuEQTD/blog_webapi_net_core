namespace InteraccionesDeHilo.Application
{
    public class SeguirHiloUseCase
    {
        private readonly IInteraccionesDeHiloService _interaccionesDeHiloService;

        public SeguirHiloUseCase(IInteraccionesDeHiloService interaccionesDeHiloService)
        {
            _interaccionesDeHiloService = interaccionesDeHiloService;
        }
        public async Task Execute(CambiarInteraccionDeHiloDto dto)
        {
            await _interaccionesDeHiloService.PonerHiloEnFavorito(dto);
        }
    }
}