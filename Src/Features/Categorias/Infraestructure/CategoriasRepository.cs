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
        public async Task Add(List<Categoria> categorias)
        {
            _context.Categorias.AddRange(categorias);
            await _context.SaveChangesAsync();
        }

        public Task Add(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            return await _context.Categorias.Include(c => c.Subcategorias).ToListAsync();
        }

        public async Task<Subcategoria?> GetSubcategoria(SubcategoriaId id)
        {
            Subcategoria? subcategoria = await _context.Subcategorias.FirstOrDefaultAsync(s => s.Id.Equals(id));
            return subcategoria;
        }

        public async Task<List<Subcategoria>> GetSubcategoriasNSFW()
        {
            List<Subcategoria> subcategoriasNSFW = await _context.Subcategorias.Where(s => s.EsNSFW).ToListAsync();
            return subcategoriasNSFW;
        }
    }
}