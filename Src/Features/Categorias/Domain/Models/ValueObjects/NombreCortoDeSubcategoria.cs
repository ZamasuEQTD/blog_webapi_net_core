using Core.Result;

namespace Categorias.Domain
{
    public class NombreCortoDeSubcategoria
    {
        public const int MinLenght = 3;
        public const int MaxLenght = 6;

        public string Value { get; private set; }

        private  NombreCortoDeSubcategoria()
        {
            
        }

        private NombreCortoDeSubcategoria(string value)
        {
            Value = value;
        }

        static public Result<NombreCortoDeSubcategoria> Create(string nombre)
        {
            if (nombre.Length > MaxLenght || nombre.Length < MinLenght)
            {
                return Result<NombreCortoDeSubcategoria>.Failure(new("Debe estar entre 3 y 6"));
            }
            return Result<NombreCortoDeSubcategoria>.Success(new NombreCortoDeSubcategoria(nombre));
        }
    }
}