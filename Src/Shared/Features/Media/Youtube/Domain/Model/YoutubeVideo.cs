using Shared.Archivos.Domain;

namespace Shared.Youtube.Domain
{
    class YoutubeVideo : ArchivoLink
    {
        public YoutubeVideoUrl VideoUrl {get;private set;} 
        public YoutubeVideo(YoutubeVideoUrl videoUrl, string fuente, bool esSpoiler) : base(fuente, esSpoiler)
        {
            VideoUrl = videoUrl;
        }
        public override bool SoportaVistaPrevia()
        {
            return true;
        }

        public override bool SoportaMiniatura()
        {
            return true;
        }
    }
}