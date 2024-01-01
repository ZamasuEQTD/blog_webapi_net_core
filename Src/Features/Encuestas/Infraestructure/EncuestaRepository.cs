using Core.Failures;
using Core.Result;
using Encuestas.Domain;
using Users.Domain;

namespace Encuestas.Infraestructure
{
    public class EncuestaRepository : IEncuestaRepository

    {
        public Task<Failure> Add(VotacionDeEncuesta votacion)
        {
            throw new NotImplementedException();
        }

        public Task<Failure> Add(Encuesta encuesta)
        {
            throw new NotImplementedException();
        }

        public Task<Result<EncuestaOpcion>> GetEncuestaOpcion(EncuestaOpcionId id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<VotacionDeEncuesta>> GetVotacionDeUsuarioEnEncuesta(UserId userId, EncuestaId encuestaId)
        {
            throw new NotImplementedException();
        }

        public Task<Failure> Update(VotacionDeEncuesta votacion)
        {
            throw new NotImplementedException();
        }

        public Task<Failure> Update(Encuesta encuesta)
        {
            throw new NotImplementedException();
        }

        public Task<Failure> Update(EncuestaOpcion opcion)
        {
            throw new NotImplementedException();
        }
    }
}