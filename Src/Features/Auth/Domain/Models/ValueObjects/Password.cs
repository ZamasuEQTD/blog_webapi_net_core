using Core.Result;

namespace Auth.Domain
{
    public sealed class Password
    {
        public static readonly int MinLenght = 8;
        public static readonly int MaxLenght = 16;

        public string Value { get; private set; }

        private Password(string value)
        {
            this.Value = value;
        }

        static public Result<Password> Create(string password)
        {
            if (password.Length < MinLenght || password.Length > MaxLenght)
            {
                return Result<Password>.Failure(new("La Contraseña debe tener entre 8 y 16 caracteres"));
            }
            return Result<Password>.Success(new Password(password));
        }
    }
}