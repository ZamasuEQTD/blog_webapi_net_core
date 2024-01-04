using Core.Result;
using Encuestas.Domain;
using Users.Domain;

namespace Encuestas.Application
{
    public class VotarEncuestaUseCase
    {
        public IEncuestaManager _encuestaManager;

        public VotarEncuestaUseCase(IEncuestaManager encuestaManager) {
            _encuestaManager = encuestaManager;
        }
        public Task<Result<VotacionDeEncuesta>> Execute(VotarEnEncuestaDto dto) {
          return  _encuestaManager.VotarEnEncuesta(new(new EncuestaOpcionId(Guid.Parse(dto.OpcionId)),new UserId(Guid.Parse(dto.UserId))));
        }
    }
}