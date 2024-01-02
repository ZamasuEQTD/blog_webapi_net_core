using Shared.Common;

namespace Categorias.Domain
{
    public record SubcategoriaId:ID
    {
        public SubcategoriaId(Guid value):base(value)
        {}


        static public SubcategoriaId Nuevo(){
            return new SubcategoriaId(Guid.NewGuid());
        }
    }
}