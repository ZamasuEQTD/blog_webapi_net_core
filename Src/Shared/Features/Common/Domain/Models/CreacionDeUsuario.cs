using Users.Domain;

namespace Shared.Common.Domain
{
    public abstract class CreacionDeUsuario : BaseModel
    {
        public User Autor { get; private set; }
        public UserId AutorId { get; private set; }

        protected CreacionDeUsuario()
        {
            
        }

        public CreacionDeUsuario(UserId autorId, User autor)
        {
            AutorId = autorId;
            Autor = autor;
        }

        public CreacionDeUsuario(User autor)
        {
            Autor = autor;
        }
    }
}