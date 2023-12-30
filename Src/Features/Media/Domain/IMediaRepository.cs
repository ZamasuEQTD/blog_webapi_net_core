using Core.Failures;
using Core.Result;

namespace Medias.Domain
{
    public interface IMediaRepository
    {
        public Task<Failure> CrearMediaReference(MediaReference media);
        public Task<Result<Media>> GetMediaByHash(string hash);

    }
}