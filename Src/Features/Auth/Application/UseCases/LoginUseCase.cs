using Auth.Domain;
using Core.Result;
using Users.Domain;

namespace Auth.Application
{
    public class LoginUseCase
    {
        private readonly IAuthManager _authManager;
        public LoginUseCase(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        public async Task Execute(LoginDto dto)
        {
            var formResult = CrearForm(dto);

            if (formResult.IsFailure)
            {
                throw new Exception(formResult.Error.Code);
            }
            await _authManager.Login(formResult.Value);
        }
        private Result<LoginForm> CrearForm(LoginDto dto)
        {
            var userNameResult = UserName.Create(dto.UserName);

            if (userNameResult.IsFailure)
            {
                return Result<LoginForm>.Failure(userNameResult.Error);
            }
            var passwordResult = Password.Create(dto.Password);

            if (passwordResult.IsFailure)
            {
                return Result<LoginForm>.Failure(userNameResult.Error);
            }

            return Result<LoginForm>.Success(new(userNameResult.Value, passwordResult.Value));
        }
    }

}