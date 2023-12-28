using Core.Failures;
using Core.Result;
using Users.Domain;

namespace Encuestas.Domain
{
    public interface IEncuestaRepository {
        public Task<Failure> Add(VotacionDeEncuesta votacion);
        public Task<Failure> Add(Encuesta encuesta);
        public Task<Failure> Update(VotacionDeEncuesta votacion);
        public Task<Failure> Update(Encuesta encuesta);
        public Task<Failure> Update(EncuestaOpcion opcion);
        public Task<Result<VotacionDeEncuesta>> GetVotacionDeUsuarioEnEncuesta(UserId userId, EncuestaId encuestaId);
        public Task<Result<EncuestaOpcion>> GetEncuestaOpcion(EncuestaOpcionId id);
    }
}