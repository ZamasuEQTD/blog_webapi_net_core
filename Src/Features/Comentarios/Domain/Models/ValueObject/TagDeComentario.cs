using Core.Result;

namespace Comentarios.Domain
{
    public class TagDeComentario
    {
        static public readonly int Length = 7;
        public string Value {get;private set;}

        private TagDeComentario(){}
        private  TagDeComentario(string value)
        {
         this.Value = value;   
        }

        static public Result<TagDeComentario> Create(string tag){
            if(tag.Length != 7){
                return Result<TagDeComentario>.Failure(new("Debe tenet 7 caracteres"));
            }
            return Result<TagDeComentario>.Success(new(tag));
        }
    }
}