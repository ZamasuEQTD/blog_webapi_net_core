using Users.Domain;

namespace Auth.Domain
{
    public class LoginForm(UserName userName, Password password)
    {
        public UserName UserName { get; private set; } = userName;
        public Password Password { get; private set; } = password;
    }
}