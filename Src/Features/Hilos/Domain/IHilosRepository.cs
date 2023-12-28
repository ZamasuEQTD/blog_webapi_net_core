

using Core.Failures;
using Core.Result;

namespace Hilos.Domain
{
    public interface IHilosRepository
    {
        public Task<Result<Hilo>> GetHilo(HiloId id);
        public Task<Result<Hilo>> GetPortadaDeHilo(HiloId id);
        public Task<Result<List<Hilo>>> GetPortadasDeHilos(GetHilosFilterDto dto);
        public Task<Result<Hilo>> ActualizarHilo(Hilo hilo);
        public Task<Failure> Add(Hilo hilo);
        public Task<Failure> EliminarHilo(Hilo hilo);
    }
}