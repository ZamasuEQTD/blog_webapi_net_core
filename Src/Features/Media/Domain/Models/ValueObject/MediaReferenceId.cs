using Shared.Common;

namespace Media.Domain
{
    public record class MediaReferenceId:ID
    {
        public MediaReferenceId(Guid id):base(id)
        {
            
        }

        public static MediaReferenceId Nuevo(){
            return  new MediaReferenceId(Guid.NewGuid());
        }
    }
}