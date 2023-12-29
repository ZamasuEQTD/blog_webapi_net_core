using Users.Domain;

namespace Auth.Domain
{
    public interface IPasswordHasherHelper {
        public HashedPassword Hash(Password password);
        public bool Verify(HashedPassword hashedPassword, Password password);
    }

    public class PasswordHasherHelper : IPasswordHasherHelper
    {
        public HashedPassword Hash(Password password)
        {
            return new(BCrypt.Net.BCrypt.EnhancedHashPassword(password.Value,13));
        }

        public bool Verify(HashedPassword hashedPassword, Password password)
        {
            return BCrypt.Net.BCrypt.Verify(password.Value, hashedPassword.Value);
        }
    }
}