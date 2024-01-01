using System.ComponentModel.DataAnnotations;

namespace Shared.Common
{
    public abstract record class ID : IEquatable<ID>
    {
        public Guid Value { get; private set; }

        protected ID() { }
        public ID(Guid id)
        {
            Value = id;
        }
        
        public virtual bool Equals(ID other) {
            return other is not null &&other.Value == this.Value;
        }
    }


}