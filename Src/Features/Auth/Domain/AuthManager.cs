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
        private readonly IPasswordHasherHelper _passwordHasher;
        public AuthManager(IUserRepository userRepository, IPasswordHasherHelper passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }
        public async Task<Result<User>> Login(LoginForm form)
        {
            User? user = await _userRepository.GetUser(form.UserName);
            if (user is null || !_passwordHasher.Verify(user.Password, form.Password))
            {
                return Result<User>.Failure(AuthFailures.UsuarioPasswordIncorrecto);
            }
            return Result<User>.Success(user);
        }

        public async Task<Result<User>> Registrar(RegistroForm form)
        {
            User? user = await _userRepository.GetUser(form.UserName);
            if (user is null)
            {
                return Result<User>.Failure(new("Usuario Existente"));
            }
            var nuevoUsuario = new User(UserId.Nuevo(), form.UserName, _passwordHasher.Hash(form.Password.Password), Rango.Usuario);
            
            await _userRepository.Add(nuevoUsuario);
            throw new NotImplementedException();
        }


    }
}