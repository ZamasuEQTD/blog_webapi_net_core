using Core.Result;

namespace Comentarios.Domain
{
    public class TextoDeComentario
    {
        public static readonly int MinLength = 10;
        public static readonly int MaxLength = 200;
        
        public string Value {get; private set;}
        private TextoDeComentario(string value) {
            Value = value;
        }

        public Result<TextoDeComentario> Create(string texto) {
            return Result<TextoDeComentario>.Success(new(texto));
        }
    }
}