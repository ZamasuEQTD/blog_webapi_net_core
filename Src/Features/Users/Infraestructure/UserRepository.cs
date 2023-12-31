using Core.Failures;
using Core.Result;
using Data;
using Microsoft.EntityFrameworkCore;
using Users.Domain;

namespace Users.Infraestructure
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Failure> Add(User user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
            return Failure.None;
        }

        public async Task<Result<User>> GetUser(UserId userId)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            if (usuario is null)
            {
                return Result<User>.Failure(new(""));
            }
            return Result<User>.Success(usuario);
        }

        public async Task<Result<User>> GetUser(UserName userName)
        {
            Console.Write("\n \n \n GetUser \n \n \n");

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.UserName.Equals(userName));
            Console.Write("\n \n \n GetUserTerminado \n \n \n");

            if (usuario is null)
            {
                return Result<User>.Failure(new(""));
            }
            return Result<User>.Success(usuario);
        }
    }
}