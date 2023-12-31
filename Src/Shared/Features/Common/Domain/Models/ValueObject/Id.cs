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
        public virtual bool Equals(ID other)
        {
            if (other is null)
            {
                return false;
            }

            return Value.Equals(other.Value);
        }


    }


}