using Shared.Common;

namespace Encuestas.Domain
{
    public record VotacionDeEncuestaId:ID
    {
        private VotacionDeEncuestaId(){}
        public VotacionDeEncuestaId(Guid id):base(id){}

        static public VotacionDeEncuestaId Nuevo() {
            return new VotacionDeEncuestaId(Guid.NewGuid());
        }    
    }
}