using Users.Domain;

namespace Encuestas.Domain
{
    public sealed class VotacionDeEncuesta
    {
        public VotacionDeEncuestaId Id { get; private set; }
        public UserId UserId { get; private set; }
        public User User { get; private set; }
        public EncuestaOpcionId OpcionId { get; private set; }
        public EncuestaOpcion Opcion { get; private set; }

        private VotacionDeEncuesta()
        {

        }

        public VotacionDeEncuesta(VotacionDeEncuestaId id, UserId userId, EncuestaOpcionId opcionId)
        {
            Id = id;
            UserId = userId;
            OpcionId = opcionId;
        }
    }
}