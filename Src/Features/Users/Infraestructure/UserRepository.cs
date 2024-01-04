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
        public async Task  Add(User user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task< User? > GetUser(UserId userId)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            return usuario;
        }

        public async Task<User?> GetUser(UserName userName)
        {

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.UserName.Equals(userName));

            return usuario;
        }
    }
}