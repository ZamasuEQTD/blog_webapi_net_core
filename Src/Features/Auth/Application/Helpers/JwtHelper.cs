using Users.Domain;

namespace Auth.Application
{
    public interface IJwtHelper {
        public string Firmar(User user);
    }

    public class JwtHelper : IJwtHelper
    {
        public string Firmar(User user)
        {
            throw new NotImplementedException();
        }
    }
}