using Shared.Common;

namespace Hilos.Domain
{
    public record HiloId : ID
    {
        private HiloId() { }
        public HiloId(Guid id) : base(id)
        {
        }

        static public HiloId Nuevo()
        {
            return new HiloId(Guid.NewGuid());
        }
    }
}