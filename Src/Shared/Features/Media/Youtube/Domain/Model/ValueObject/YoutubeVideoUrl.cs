using Core.Result;
using Shared.Archivos.Domain;

namespace Shared.Youtube.Domain
{
    public class YoutubeVideoUrl
    {
        public UrlLink Url {get;private set;}
        public string VideoID {get;private set;}
        private YoutubeVideoUrl(UrlLink url,string id)
        {
            this.VideoID = id;
            this.Url = url;
        }
        static public Result<YoutubeVideoUrl> Create(UrlLink url) {
            return Result<YoutubeVideoUrl>.Failure(YoutubeFailures.SinVideoId);
        }
    }
}