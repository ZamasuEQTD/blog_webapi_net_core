using Shared.Common;

namespace Categorias.Domain
{
    public record CategoriaId:ID
    {
        public CategoriaId(Guid value):base(value)
        {}
    }
}