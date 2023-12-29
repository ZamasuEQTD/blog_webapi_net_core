using Core.Result;
using Users.Domain;

namespace Users.Domain
{
    public interface IUserRepository
    {
        public Task<Result<User>> GetUser(UserId userId);
        public Task<Result<User>> GetUser(UserName userId);

    }
}