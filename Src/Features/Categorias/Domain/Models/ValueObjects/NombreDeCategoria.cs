using Core.Result;

namespace Categorias.Domain
{
    public class NombreDeCategoria
    {
        public readonly static int MinLenght = 3;
        public readonly static int MaxLenght = 12;

        public string Value { get; private set; }
        private NombreDeCategoria(string nombre)
        {
            this.Value = nombre;
        }

        public static Result<NombreDeCategoria> Create(string nombre)
        {
            return Result<NombreDeCategoria>.Success(new NombreDeCategoria(nombre));
        }
    }
}