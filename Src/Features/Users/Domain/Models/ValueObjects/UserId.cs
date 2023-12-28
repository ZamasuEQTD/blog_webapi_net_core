using Shared.Common;

namespace Users.Domain
{
    
    public sealed record  UserId:ID {
        private  UserId()
        {
            
        }
        public UserId(Guid id):base(id)
        {
            
        }
    }
}