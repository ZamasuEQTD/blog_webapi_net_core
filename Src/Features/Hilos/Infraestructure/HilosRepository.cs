using Core.Failures;
using Core.Result;
using Data;
using Hilos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hilos.Infraestructure
{
    public class HilosRepository : IHilosRepository
    {
        private readonly DataContext _context;
        public HilosRepository(DataContext context)
        {
            _context = context;
        }
        public Task<Result<Hilo>> ActualizarHilo(Hilo hilo)
        {
            throw new NotImplementedException();
        }

        public async Task<Failure> Add(Hilo hilo)
        {
            await _context.Hilos.AddAsync(hilo);
            await _context.SaveChangesAsync();
            return Failure.None;
        }

        public Task<Failure> EliminarHilo(Hilo hilo)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Hilo>> GetHilo(HiloId id)
        {
            Hilo? hilo =await  _context.Hilos.Include(h=> h.Media).ThenInclude(m => m.Media).Include(h=> h.Encuesta).ThenInclude(e=> e.Opciones).FirstOrDefaultAsync(h=> h.Id.Equals(id));

            if(hilo is null) {
                return Result<Hilo>.Failure(new Failure("No encontrado"));
            }
            return Result<Hilo>.Success(hilo);

        }

        public Task<Result<Hilo>> GetPortadaDeHilo(HiloId id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Hilo>>> GetPortadasDeHilos(GetHilosFilterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}