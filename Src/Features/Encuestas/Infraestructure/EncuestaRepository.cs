using Core.Failures;
using Core.Result;
using Data;
using Encuestas.Domain;
using Microsoft.EntityFrameworkCore;
using Users.Domain;

namespace Encuestas.Infraestructure
{
    public class EncuestaRepository : IEncuestaRepository

    {
        private readonly DataContext _context;

        public EncuestaRepository(DataContext context)
        {
            _context = context;
        }
        public Task Add(VotacionDeEncuesta votacion)
        {
            throw new NotImplementedException();
        }

        public Task Add(Encuesta encuesta)
        {
            throw new NotImplementedException();
        }

        public Task<Encuesta?> GetEncuesta(EncuestaId id)
        {
            return _context.Encuestas.Include(e => e.Votos).FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public Task<EncuestaOpcion?> GetEncuestaOpcion(EncuestaOpcionId id)
        {
            return _context.OpcionesDeEncuestas.FirstOrDefaultAsync(o => o.Id.Equals(id));
        }

        public async Task<VotacionDeEncuesta?> GetVotacionDeUsuarioEnEncuesta(UserId userId, EncuestaId encuestaId)
        {
            Encuesta? encuesta = await GetEncuesta(encuestaId);

            if (encuesta is null)
            {
                throw new Exception("Encuesta no encontrada");
            }

            VotacionDeEncuesta? votoExistente = encuesta.Votos.FirstOrDefault(v => v.UserId.Equals(userId));

            return votoExistente;
        }

        public async Task Update(VotacionDeEncuesta votacion)
        {
            _context.VotosDeEncuesta.Update(votacion);
            await _context.SaveChangesAsync();
        }

        public Task Update(Encuesta encuesta)
        {
            throw new NotImplementedException();
        }

        public async Task Update(EncuestaOpcion opcion)
        {
            _context.OpcionesDeEncuestas.Update(opcion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UsuarioHaVotadoEncuesta(UserId userId, EncuestaId encuestaId)
        {
            VotacionDeEncuesta? votacionExistente = await GetVotacionDeUsuarioEnEncuesta(userId, encuestaId);

            return votacionExistente is not null;
        }
    }
}