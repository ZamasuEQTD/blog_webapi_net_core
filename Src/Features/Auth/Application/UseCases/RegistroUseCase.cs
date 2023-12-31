using Auth.Domain;
using Core.Result;
using Users.Domain;

namespace Auth.Application
{
    public class RegistroUseCase
    {
        public IAuthManager _authManager;
        public RegistroUseCase(IAuthManager authManager)
        {
            _authManager = authManager;
        }
        public async Task Execute(RegistroDto registro)
        {
            var formResult = CrearForm(registro);
            if (formResult.IsFailure)
            {
                throw new Exception(formResult.Error.Code);
            }
            await _authManager.Registrar(formResult.Value);
        }
        private Result<RegistroForm> CrearForm(RegistroDto dto)
        {
            var userNameResult = UserName.Create(dto.UserName);

            if (userNameResult.IsFailure)
            {
                return Result<RegistroForm>.Failure(userNameResult.Error);
            }

            var passwordsResult = RegistroPassword.Create(dto.Password, dto.PasswordRepetida);

            if (passwordsResult.IsFailure)
            {
                return Result<RegistroForm>.Failure(passwordsResult.Error);
            }
            return Result<RegistroForm>.Success(new RegistroForm(userNameResult.Value, passwordsResult.Value));
        }

    }
}