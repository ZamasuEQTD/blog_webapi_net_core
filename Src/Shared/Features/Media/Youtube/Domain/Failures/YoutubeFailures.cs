using Core.Failures;

namespace Shared.Youtube.Domain
{
    static public class YoutubeFailures
    {
        static public readonly Failure SinVideoId = new Failure("Youtube.SinVideoId", "Sin ID de video");
    }
}