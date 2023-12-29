using Users.Domain;

namespace Encuestas.Domain
{
    public sealed record VotarEncuestaForm(EncuestaOpcionId OpcionId, UserId UserId);
     
}