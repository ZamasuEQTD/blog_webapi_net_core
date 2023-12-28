using Users.Domain;

namespace Encuestas.Domain
{
    public record CrearEncuestaForm
    {
        public UserId UserId {get;private set;}
        public OpcionesDeEncuesta OpcionesDeEncuesta {get;private set;}
    
    }
}