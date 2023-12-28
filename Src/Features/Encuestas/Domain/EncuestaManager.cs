using Core.Failures;
using Core.Result;

namespace Encuestas.Domain
{
    public interface IEncuestaManager {
        public Task<Result<Encuesta>>CrearEncuesta(CrearEncuestaForm form);
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
            EncuestaId encuestaId = EncuestaId.Nuevo();
            List<EncuestaOpcion> opcions = [];
            foreach (var nombreDeOpcion in form.OpcionesDeEncuesta.Value)
            {
                opcions.Add(new EncuestaOpcion(EncuestaOpcionId.Nuevo(),encuestaId,nombreDeOpcion,VotosDeEncuesta.Create(0).Value));
            }
            Encuesta nuevaEncuesta = new Encuesta(encuestaId,opcions);
            await _encuestaRepository.Add(nuevaEncuesta);
            return Result<Encuesta>.Success(nuevaEncuesta);
        }

        public async  Task<Result<VotacionDeEncuesta>> VotarEnEncuesta(VotarEncuestaForm form)
        {
            var opcionResult =await  _encuestaRepository.GetEncuestaOpcion(form.OpcionId);

            EncuestaOpcion opcion = opcionResult.Value;      
            var votacionExistente = await _encuestaRepository.GetVotacionDeUsuarioEnEncuesta(form.UserId,opcionResult.Value.EncuestaId);
            
            if(votacionExistente.IsSuccess) {
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