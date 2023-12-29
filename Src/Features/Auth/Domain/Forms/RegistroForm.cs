using Users.Domain;

namespace Auth.Domain
{
    public sealed class RegistroForm
    {
        public UserName UserName { get; private set; }
        public RegistroPassword Password { get; private set; }
        public RegistroForm(UserName userName, RegistroPassword password)
        {
            UserName = userName;
            Password = password;
        }
        
    }
}