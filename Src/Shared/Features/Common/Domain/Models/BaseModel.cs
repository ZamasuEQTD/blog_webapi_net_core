namespace Shared.Common.Domain
{
    public abstract class BaseModel
    {
        public DateTime CreatedAt { get; private set; } = DateTime.Now.ToUniversalTime();
    }
}