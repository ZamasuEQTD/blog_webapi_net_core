using Core.Failures;
using Core.Result;
using Users.Domain;

namespace Users.Domain
{
    public interface IUserRepository
    {
        public Task<User?> GetUser(UserId userId);
        public Task<User?> GetUser(UserName userId);
        public Task Add(User user);
    }
}