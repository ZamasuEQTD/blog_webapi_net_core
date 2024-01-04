using Core.Result;

namespace Comentarios.Domain
{
    public class TagUnico
    {
        public static readonly int Length = 3;

        public string Value {get;set;}

        private TagUnico(string value)
        {
            Value = value;
        }
        static public Result<TagUnico>Create( string tag ){
            return Result<TagUnico>.Success(new(tag));
        }
    }
}