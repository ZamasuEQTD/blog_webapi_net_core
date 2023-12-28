namespace Shared.Common
{
    public record class ID
    {
        public  Guid Value { get; private set; }

        protected  ID() { }
        public ID(Guid id)
        {
            Value = id;
        }
    }

    
}