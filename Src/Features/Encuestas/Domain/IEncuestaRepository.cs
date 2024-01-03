using Core.Failures;
using Core.Result;
using Users.Domain;

namespace Encuestas.Domain
{
    public interface IEncuestaRepository
    {
        public Task Add(VotacionDeEncuesta votacion);
        public Task Add(Encuesta encuesta);
        public Task Update(VotacionDeEncuesta votacion);
        public Task Update(Encuesta encuesta);
        public Task Update(EncuestaOpcion opcion);
        public Task<VotacionDeEncuesta?> GetVotacionDeUsuarioEnEncuesta(UserId userId, EncuestaId encuestaId);
        public Task<EncuestaOpcion?> GetEncuestaOpcion(EncuestaOpcionId id);
        public Task<Encuesta?> GetEncuesta(EncuestaId id);
        public Task<bool> UsuarioHaVotadoEncuesta(UserId userId, EncuestaId encuestaId);

    }
}