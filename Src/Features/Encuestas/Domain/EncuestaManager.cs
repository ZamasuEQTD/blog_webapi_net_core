using Core.Failures;
using Core.Result;

namespace Encuestas.Domain
{
    public interface IEncuestaManager
    {
        public Task<Result<Encuesta>> CrearEncuesta(CrearEncuestaForm form);
        public Task<Result<VotacionDeEncuesta>> VotarEnEncuesta(VotarEncuestaForm form);

    }
    class EncuestaManager : IEncuestaManager
    {
        public IEncuestaRepository _encuestaRepository;
        public EncuestaManager(IEncuestaRepository encuestaRepository)
        {
            _encuestaRepository = encuestaRepository;
        }
        public async Task<Result<Encuesta>> CrearEncuesta(CrearEncuestaForm form)
        {
            EncuestaId encuestaId = new(Guid.NewGuid());
            List<EncuestaOpcion> opcions = [];
            foreach (var nombreDeOpcion in form.OpcionesDeEncuesta.Value)
            {
                opcions.Add(new EncuestaOpcion(EncuestaOpcionId.Nuevo(), encuestaId, nombreDeOpcion, VotosDeEncuesta.Create(0).Value));
            }
            Encuesta nuevaEncuesta = new Encuesta(encuestaId, opcions);
            return Result<Encuesta>.Success(nuevaEncuesta);
        }

        public async Task<Result<VotacionDeEncuesta>> VotarEnEncuesta(VotarEncuestaForm form)
        {
            EncuestaOpcion? opcion = await _encuestaRepository.GetEncuestaOpcion(form.OpcionId);

            if (opcion is null)
            {
                return Result<VotacionDeEncuesta>.Failure(new("OpcionInexistente"));
            }
            if (await _encuestaRepository.UsuarioHaVotadoEncuesta(form.UserId, opcion.EncuestaId))
            {
                return Result<VotacionDeEncuesta>.Failure(new Failure("Yas votado!!!"));
            }
            
            VotacionDeEncuesta votacion = new(VotacionDeEncuestaId.Nuevo(), form.UserId, opcion.Id);

            await _encuestaRepository.Add(votacion);

            opcion.SumarVoto();

            await _encuestaRepository.Update(opcion);
            return Result<VotacionDeEncuesta>.Success(votacion);
        }
    }
}