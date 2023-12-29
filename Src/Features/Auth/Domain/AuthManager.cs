using Core.Failures;
using Core.Result;
using Users.Domain;

namespace Auth.Domain
{
    public interface IAuthManager
    {
        public Task<Result<User>> Registrar(RegistroForm form);
        public Task<Result<User>> Login(LoginForm form);
    }

    public class AuthManager : IAuthManager
    {
        private readonly IUserRepository _userRepository;
        public async Task<Result<User>> Login(LoginForm form)
        {
            var userResult = await _userRepository.GetUser(form.UserName);
            if (userResult.IsFailure)
            {
                return Result<User>.Failure(new("Usuario o Contraseña incorrecta"));
            }
            throw new NotImplementedException();
        }

        public async Task<Result<User>> Registrar(RegistroForm form)
        {
            var userResult = await _userRepository.GetUser(form.UserName);
            if (userResult.IsSuccess)
            {
                return Result<User>.Failure(new("Usuario Existente"));
            }

            throw new NotImplementedException();
        }
    }
}