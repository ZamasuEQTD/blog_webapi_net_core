using Core.Failures;
using Core.Result;
using Shared.Common.Domain;
using Users.Domain;

namespace Hilos.Domain
{
    public interface IHiloManager
    {
        public Task<Result<Hilo>> GetHiloById(HiloId id, UserId? usuario = null);
        public Task<Result<List<Hilo>>> GetPortadasDeHilos(GetHilosFilterDto dto);
        public Task<Result<Hilo>> CrearHilo(CrearHiloForm form);
    }

    public class HiloManager : IHiloManager
    {
        private readonly IHilosRepository _hilosRepository;
        private readonly IUserRepository _userRepository;
        public HiloManager(IHilosRepository hilosRepository, IUserRepository userRepository)
        {
            _hilosRepository = hilosRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<Hilo>> CrearHilo(CrearHiloForm form)
        {
            var userResult = await _userRepository.GetUser(form.User);

            Hilo nuevoHilo = new(HiloId.Nuevo(), form.SubcategoriaId, userResult!, form.Media, form.Titulo, form.Descripcion, form.Banderas, form.Encuesta);

            await _hilosRepository.Add(nuevoHilo);

            return Result<Hilo>.Success(nuevoHilo);
        }

        public async Task<Result<Hilo>> GetHiloById(HiloId id, UserId? usuario = null)
        {
            return Result<Hilo>.Success(await _hilosRepository.GetHilo(id));
        }

        public async Task<Result<List<Hilo>>> GetPortadasDeHilos(GetHilosFilterDto dto)
        {
            return Result<List<Hilo>>.Success(await  _hilosRepository.GetPortadasDeHilos(dto));
        }


    }
}