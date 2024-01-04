using Shared.Common;

namespace Comentarios.Domain
{
    public record ComentarioId : ID
    {
        public ComentarioId(Guid original) : base(original)
        {
        }
    }
}