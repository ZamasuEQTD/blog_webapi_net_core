
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Shared.Imagess
{
    public interface IImagesHelper
    {
        public Task<Image> ResizeImage(Stream stream, Size size, ResizeMode? ResizeMode = null, AnchorPositionMode? PositionMode = null);
        public Task<string> GuardarImagen(Image imagen, string OutputFolder, string Nombre);
        public Task<string> GuardarImageStream(Stream imagen, string OutputFolder, string Nombre);
        public Task<Stream> GetStreamImageFromUrl(string url);
    }


    public class ImagesHelper : IImagesHelper
    {
        public Task<Stream> GetStreamImageFromUrl(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GuardarImagen(Image imagen, string outputFolder, string nombre)
        {
            var output = outputFolder + "/" + nombre + ".png";
            await imagen.SaveAsync(output);
            return output;
        }

        public async Task<string> GuardarImageStream(Stream imagen, string outputFolder, string nombre)
        {
            Image image = await Image.LoadAsync(imagen);

            return await GuardarImagen(image, outputFolder, nombre);
        }

        public async Task<Image> ResizeImage(Stream stream, Size size, ResizeMode? resizeMode = null, AnchorPositionMode? positionMode = null)
        {
            var original = await Image.LoadAsync(stream);
            original = original.Clone(e => e.Resize(new ResizeOptions()
            {
                Mode = resizeMode ?? ResizeMode.Max,
                Position = positionMode ?? AnchorPositionMode.Center,
                Size = size
            }));
            return original;
        }
    }
}