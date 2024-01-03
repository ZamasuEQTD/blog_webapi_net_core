

using Core.Failures;
using Core.Result;

namespace Hilos.Domain
{
    public interface IHilosRepository
    {
        public Task<Hilo?> GetHilo(HiloId id);
        public Task<Hilo?> GetPortadaDeHilo(HiloId id);
        public Task<List<Hilo>> GetPortadasDeHilos(GetHilosFilterDto dto);
        public Task ActualizarHilo(Hilo hilo);
        public Task Add(Hilo hilo);
    }
}