
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Shared.Imagess
{
    public interface IImagesHelper
    {
        public Task<Image> ResizeImage(Stream Stream, Size size, ResizeMode? ResizeMode = null, AnchorPositionMode? PositionMode = null);
        public Task<string> GuardarImagen(Image imagen, string OutputFolder, string Nombre);
        public Task<string> GuardarImageStream(Stream imagen, string OutputFolder, string Nombre);
        public Task<Stream> GetStreamImageFromUrl(string url);
    }
}