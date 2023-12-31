using Shared.Common;

namespace Medias.Domain
{

    public record class MediaId : ID
    {
        public MediaId() { }
        public MediaId(Guid id) : base(id)
        {
        }
        static public MediaId Nuevo()
        {
            return new MediaId(Guid.NewGuid());
        }
    }
}