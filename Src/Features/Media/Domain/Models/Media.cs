namespace Medias.Domain
{
    public class Media
    {
        public MediaId Id { get; private set; }
        public string Hash { get; private set; }
        public string Url { get; private set; }
        private Media() { }
        public Media(MediaId id, string hash, string url)
        {
            Id = id;
            Hash = hash;
            Url = url;
        }
    }
}