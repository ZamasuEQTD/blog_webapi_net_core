using Core.Result;
using Hilos.Domain;
using Users.Domain;

namespace Hilos.Application
{
    public class GetHiloUseCase
    {
        private readonly IHiloManager _hiloManager;
        public GetHiloUseCase( )
        {
        }

        public async Task<Result<Hilo>> Execute(GetHiloDto dto)
        {
            return   await _hiloManager.GetHiloById(new(Guid.Parse(dto.HiloId)));
        }
    }
}