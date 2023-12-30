using Shared.Common;

namespace Encuestas.Domain
{
    public record EncuestaOpcionId : ID
    {
        private EncuestaOpcionId() { }
        public EncuestaOpcionId(Guid id) : base(id) { }
        static public EncuestaOpcionId Nuevo()
        {
            return new EncuestaOpcionId(Guid.NewGuid());
        }
    }
}