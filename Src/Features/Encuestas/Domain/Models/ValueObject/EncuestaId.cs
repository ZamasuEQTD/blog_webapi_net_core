using Shared.Common;

namespace Encuestas.Domain
{
    public record  EncuestaId:ID
    {
        private EncuestaId(){}
        public EncuestaId(Guid id):base(id){}

        static public EncuestaId Nuevo() {
            return new EncuestaId(Guid.NewGuid());
        }
    }
}