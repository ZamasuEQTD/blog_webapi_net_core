using Shared.Common;

namespace Users.Domain
{

    public sealed record UserId : ID
    {
        private UserId()
        {

        }
        public UserId(Guid id) : base(id)
        {
        }

        static public UserId Nuevo()
        {
            return new UserId(Guid.NewGuid());
        }
    }
}