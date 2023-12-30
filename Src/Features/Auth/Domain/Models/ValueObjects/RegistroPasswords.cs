using Core.Result;

namespace Auth.Domain
{
    public sealed class RegistroPassword
    {
        public Password Password { get; private set; }

        private RegistroPassword(Password password)
        {
            Password = password;
        }

        static public Result<RegistroPassword> Create(string password, string passwordRep)
        {
            var passwordResult = Password.Create(password);

            if (passwordResult.IsFailure)
            {
                return Result<RegistroPassword>.Failure(passwordResult.Error);
            }
            if (!passwordResult.Value.Equals(passwordRep))
            {
                return Result<RegistroPassword>.Failure(new("Ambas contraseñas deben ser iguales"));
            }
            return Result<RegistroPassword>.Success(new(passwordResult.Value));
        }
    }
}