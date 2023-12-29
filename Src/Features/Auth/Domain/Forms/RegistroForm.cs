using Users.Domain;

namespace Auth.Domain
{
    public sealed class RegistroForm
    {
        public RegistroPassword Password { get; private set; }
        public UserName UserName { get; private set; }
    }
}