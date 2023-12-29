using Core.Failures;
using Core.Result;
using Shared.Common.Domain;
using Users.Domain;

namespace Hilos.Domain
{
    public interface IHiloManager {
        public Task<Result<Hilo>> GetHiloById(HiloId id,User? usuario = null);
        public Task<Result<List<Hilo>>> GetPortadasDeHilos(GetHilosFilterDto dto);
        public Task<Result<Hilo>> CrearHilo(CrearHiloForm form);
    }

    public class HiloManager : IHiloManager
    {
        private readonly IHilosRepository _hilosRepository;

        public HiloManager(IHilosRepository hilosRepository)
        {
            _hilosRepository = hilosRepository;
        }

        public Task<Result<Hilo>> CrearHilo(CrearHiloForm form)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Hilo>> GetHiloById(HiloId id, User? usuario = null)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Hilo>>> GetPortadasDeHilos(GetHilosFilterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}