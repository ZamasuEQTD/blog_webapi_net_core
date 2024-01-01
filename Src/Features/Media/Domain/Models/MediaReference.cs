using Medias.Domain;

namespace Medias.Domain
{
    public sealed class MediaReference
    {
        public MediaReferenceId Id { get; private set; }
        public MediaId MediaId { get; private set; }
        public Media Media { get; private set; }
        public bool EsSpoiler { get; private set; }
        private MediaReference() { }
        public MediaReference(MediaReferenceId id, MediaId mediaId, Media media, bool esSpoiler)
        {
            Id = id;
            MediaId = mediaId;
            Media = media;
            EsSpoiler = esSpoiler;
        }
        public MediaReference(MediaReferenceId id, Media media, bool esSpoiler)
        {
            Id = id;
            Media = media;
            EsSpoiler = esSpoiler;
        }
        public MediaReference(MediaReferenceId id, MediaId mediaId, bool esSpoiler)
        {
            Id = id;
            MediaId = mediaId;
            EsSpoiler = esSpoiler;
        }
    }
}