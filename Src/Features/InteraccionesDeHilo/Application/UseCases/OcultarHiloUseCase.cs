using Core.Failures;
using InteraccionesDeHilo.Domain;

namespace InteraccionesDeHilo.Application
{
    public class OcultarHiloUseCase
    {
        private readonly IInteraccionesDeHiloService _interaccionesDeHiloService;

        public OcultarHiloUseCase(IInteraccionesDeHiloService interaccionesDeHiloService)
        {
            _interaccionesDeHiloService = interaccionesDeHiloService;
        }

        public async Task  Execute(CambiarInteraccionDeHiloDto dto) {
            await  _interaccionesDeHiloService.OcultarHilo(dto);
        }
    }
}