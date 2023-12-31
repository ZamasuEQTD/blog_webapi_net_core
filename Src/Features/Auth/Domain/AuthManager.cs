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

            var nuevoUsuario = new User(UserId.Nuevo(), form.UserName, _passwordHasher.Hash(form.Password.Password), Rango.Usuario);
            Console.Write(" \n\n\n\n Creando Usuariooooooooooooo \n\n\n\n");
            await _userRepository.Add(nuevoUsuario);
            throw new NotImplementedException();
        }

    }
}