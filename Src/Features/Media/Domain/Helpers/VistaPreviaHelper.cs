using Xabe.FFmpeg;

namespace Medias.Domain
{
    public interface IVistaPreviaHelper
    {
        public Task<string> GenerarVistaPreviaDesdeVideo(string path);
        public Task<string> GenerarVistaPreviaDesdeImagen(string path);
        public Task<string> GenerarDesdeYoutubeVideoId(string id);
    }

    public class VistaPreviaHelper : IVistaPreviaHelper
    {

        public string _outputFolder;
        public Task<string> GenerarDesdeYoutubeVideoId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerarVistaPreviaDesdeImagen(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerarVistaPreviaDesdeVideo(string path)
        {
            var output = Path.Combine(_outputFolder, Path.GetFileName(path) + ".png"); ;
            var file = await FFmpeg.Conversions.FromSnippet.Snapshot(path, output, TimeSpan.FromSeconds(0));
            await file.Start();
            return output;
        }
    }
}