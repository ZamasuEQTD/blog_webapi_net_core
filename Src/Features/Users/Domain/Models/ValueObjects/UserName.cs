
using Core.Failures;
using Core.Result;

namespace Users.Domain
{
    public sealed record UserName
    {
        private const int MaxLenght = 20;
        private const int MinLenght = 8;

        public string Value { get; }

        public UserName () {}
        private UserName(string value)
        {
            this.Value = value;
        }

        public static Result<UserName> Create(string userName)
        {
            if (userName.Length == 0)
            {
                Result<UserName>.Failure(new Failure("UserName.Invalido", "El nombre de usuario debe tener entre " + MinLenght.ToString() + " y " + MaxLenght.ToString()));
            }
            if (userName.Length > MaxLenght)
            {
                Result<UserName>.Failure(new Failure("UserName.Invalido", "El nombre de usuario debe tener entre " + MinLenght.ToString() + " y " + MaxLenght.ToString()));
            }
            return Result<UserName>.Success(new UserName(userName));
        }
    }
}