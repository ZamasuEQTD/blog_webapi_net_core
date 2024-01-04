using Core.Failures;
using Core.Result;
using Data;
using Medias.Domain;
using Microsoft.EntityFrameworkCore;

namespace Medias.Infraestructure
{
    public class MediaRepository : IMediaRepository
    {
        private readonly DataContext _context;

        public MediaRepository(DataContext context)
        {
            _context = context;
        }
         

        public  async Task<Media?> GetMediaByHash(string hash)
        {
            Media? media = await _context.Medias.FirstOrDefaultAsync(m => m.Hash == hash);
            return media;
        }
    }
}