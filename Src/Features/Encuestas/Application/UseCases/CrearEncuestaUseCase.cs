using Core.Result;
using Encuestas.Domain;
using Users.Domain;

namespace Encuestas.Application
{
    public class CrearEncuestaUseCase
    {
        public IEncuestaManager _encuestaManager;
        public CrearEncuestaUseCase(IEncuestaManager encuestaManager)
        {
            _encuestaManager = encuestaManager;
        }
        public async Task<Result<Encuesta>> Execute(CrearEncuestaDto dto) {
            var opcionResult = OpcionesDeEncuesta.Create(dto.Opciones);
            if(opcionResult.IsFailure) {
                return Result<Encuesta>.Failure(opcionResult.Error);
            }
            return await _encuestaManager.CrearEncuesta(new CrearEncuestaForm(opcionResult.Value));
        }
    }
}