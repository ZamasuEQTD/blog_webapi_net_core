using Core.Failures;
using Core.Result;
using Data;
using Hilos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Hilos.Infraestructure
{
    public class HilosRepository : IHilosRepository
    {
        private readonly DataContext _context;
        public HilosRepository(DataContext context)
        {
            _context = context;
        }
        public Task ActualizarHilo(Hilo hilo)
        {
            throw new NotImplementedException();
        }

        public async Task Add(Hilo hilo)
        {
            await _context.Hilos.AddAsync(hilo);
            await _context.SaveChangesAsync();
        }

        public Task EliminarHilo(Hilo hilo)
        {
            throw new NotImplementedException();
        }

        public async Task<Hilo?> GetHilo(HiloId id)
        {
            Hilo? hilo = await _context.Hilos.Include(h => h.Subcategoria).Include(h => h.Media).ThenInclude(m => m.Media).Include(h => h.Encuesta).ThenInclude(e => e.Opciones).FirstOrDefaultAsync(h => h.Id.Equals(id));
            return hilo;
        }

        public Task<Hilo?> GetPortadaDeHilo(HiloId id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Hilo>> GetPortadasDeHilos(GetHilosFilterDto dto)
        {
            IQueryable<Hilo> hilosQuery = _context.Hilos;

            if (!dto.CategoriasOcultas.IsNullOrEmpty())
            {
                hilosQuery = hilosQuery.Where(h => !dto.CategoriasOcultas.Contains(h.SubcategoriaId));
            }

            if (!dto.HilosParaOcultar.IsNullOrEmpty())
            {
                hilosQuery = hilosQuery.Where(h => dto.HilosParaOcultar.Contains(h.Id));
            }
            hilosQuery = hilosQuery.PorPagina(0).Include(h => h.Media).ThenInclude(m => m.Media).Include(h => h.Subcategoria);
            return await hilosQuery.ToListAsync();
        }
    }
}