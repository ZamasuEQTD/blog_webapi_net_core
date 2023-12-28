using System.Security.Cryptography;

namespace Shared.Hasher
{
    public interface IHasherHelper
    {
        public Task<string> HashStreamAsync(Stream stream);
    }

    public class HasherService : IHasherHelper
    {
        private readonly MD5 MD5 = MD5.Create();

        public async Task<string> HashStreamAsync(Stream stream)
        {
            var hash = await MD5.ComputeHashAsync(stream);
            return string
                .Join("", hash.Select(e => e.ToString("x2")));
        }
    }
}