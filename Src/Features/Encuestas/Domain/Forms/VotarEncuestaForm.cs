using Users.Domain;

namespace Encuestas.Domain
{
    public class VotarEncuestaForm
    {
        public EncuestaOpcionId OpcionId {get;private set;}
        public UserId UserId {get;private set;}
    }
}