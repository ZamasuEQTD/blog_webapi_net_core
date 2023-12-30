using Shared.Archivos.Domain;
using Shared.Imagess;
using SixLabors.ImageSharp;

namespace Medias.Domain
{
    public interface IMiniaturaHelper
    {
        public Task<string> CrearMiniatura(string path, string? nombre = null);
        public Task<string> CrearMiniatura(Stream file, string? nombre = null);

    }
    class MiniaturaHelper : IMiniaturaHelper
    {
        private readonly string _outputFolder;
        private readonly IArchivosHelper _archivosHelper;
        private readonly IImagesHelper _imagesHelper;
        public async Task<string> CrearMiniatura(string path, string? nombre = null)
        {
            var imagenStream = await _archivosHelper.CrearStreamFromFile(path);
            nombre = Path.GetFileNameWithoutExtension(path);

            var miniatura = await CrearMiniatura(imagenStream, nombre);
            imagenStream.Close();
            return miniatura;
        }

        public async Task<string> CrearMiniatura(Stream file, string? nombre = null)
        {
            var output = Path.Combine(_outputFolder, nombre + ".png");
            var miniatura = await _imagesHelper.ResizeImage(file, new Size(200, 200));
            await miniatura.SaveAsync(output);

            return output;
        }
    }
}