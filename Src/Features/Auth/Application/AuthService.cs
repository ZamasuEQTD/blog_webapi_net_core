using Auth.Domain;
using Core.Result;
using Users.Domain;

namespace Auth.Application
{
    public interface IAuthService {
        public Task<Result<TokenDto>> Login(LoginDto login);
        public Task<Result<TokenDto>> Registro(RegistroDto login);
    }

    public class AuthService : IAuthService
    {
        public IAuthManager _authManager;
        public async Task<Result<TokenDto>> Login(LoginDto login)
        {
            var formResult = CrearForm(login);
            await _authManager.Login(formResult.Value);
            throw new NotImplementedException();
        }

        public async Task<Result<TokenDto>> Registro(RegistroDto registro)
        {
            var formResult = CrearForm(registro);
            
            await _authManager.Registrar(formResult.Value);
            throw new NotImplementedException();
        }

        private Result<LoginForm> CrearForm(LoginDto dto) {
            var userNameResult = UserName.Create(dto.UserName);

            if(userNameResult.IsFailure)  {
                return Result<LoginForm>.Failure(userNameResult.Error);
            }
            var passwordResult = Password.Create(dto.Password);

            if (passwordResult.IsFailure)
            {
                return Result<LoginForm>.Failure(userNameResult.Error);
            }

            return Result<LoginForm>.Success(new(userNameResult.Value,passwordResult.Value));
        }

        private Result<RegistroForm> CrearForm(RegistroDto dto) {
            var userNameResult = UserName.Create(dto.UserName);
           
            if(userNameResult.IsFailure)  {
                return Result<RegistroForm>.Failure(userNameResult.Error);
            }
            var passwordsResult = RegistroPassword.Create(dto.Password,dto.PasswordRepetida);

            if (passwordsResult.IsFailure)
            {
                return Result<RegistroForm>.Failure(passwordsResult.Error);
            }
            return Result<RegistroForm>.Success(new RegistroForm(userNameResult.Value,passwordsResult.Value));
        }
    }
}
