using Core.Result;
using Hilos.Domain;
using Shared.Common.Domain;

namespace Hilos.Application
{
    public class GetPortadasDeHilosUseCase
    {
        private readonly IHiloManager _hiloManager;

        public GetPortadasDeHilosUseCase(IHiloManager hiloManager)
        {
            _hiloManager = hiloManager;
        }

        public Task<Result<List<Hilo>>> Execute(FiltrarPortadasDeHilosDto dto)
        {
            return _hiloManager.GetPortadasDeHilos(new GetHilosFilterDto(Pagina.Create(dto.Pagina).Value, new(), new()));
        }

    }
}