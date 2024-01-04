using System.Data;
using Comentarios.Domain;
using Data;
using Hilos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Comentarios.Infraestructure
{
    public class ComentariosRepository : IComentariosRepository
    {
        public DataContext _context;
        public ComentariosRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Add(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);

            await _context.SaveChangesAsync();
        }

        public async  Task<List<Comentario>> GetComentariosDeHilo(HiloId hiloId)
        {
            var comentarios = _context.Comentarios
            .Where(c=> c.HiloId.Equals(hiloId))
            .PorPagina(1).Include(c=> c.Media).Include(c=>c.Autor);
            return await comentarios.ToListAsync();
        }

        public Task<List<Comentario>> GetComentariosDestacadosDeHilo(HiloId hiloId)
        {
            throw new NotImplementedException();
        }

        public Task Update(Comentario comentario)
        {
            throw new NotImplementedException();
        }
    }
}