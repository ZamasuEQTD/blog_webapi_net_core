using Categorias.Domain;
using Core.Failures;
using Core.Result;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Categorias.Infraestructure
{
    public class CategoriasRepository : ICategoriasRepository
    {
        public DataContext _context;

        public CategoriasRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Failure> Add(List<Categoria> categorias)
        {
            _context.Categorias.AddRange(categorias);
            await  _context.SaveChangesAsync();
            return Failure.None;
        }

        public Task<Failure> Add(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public async  Task<Result<List<Categoria>>> GetCategorias()
        {
          return Result<List<Categoria>>.Success(await  _context.Categorias.Include(c=> c.Subcategorias).ToListAsync());
        }

        public Task<Result<Subcategoria>> GetSubcategoria(SubcategoriaId id)
        {
            throw new NotImplementedException();
        }
    }
}