using Core.Failures;
using Core.Result;

namespace Shared.Common.Domain
{
    public record Pagina
    {
        public int Value {get;private set;}

        private  Pagina(int pagina)
        {
            Value = pagina;
        }
        static public Result<Pagina> Create(int pagina) {
            if(pagina < 0) {
                return Result<Pagina>.Failure(new Failure("Pagina.Invalida", "La pagina debe ser mayor a 1"));
            }

            return Result<Pagina>.Success(new Pagina(pagina));
        }
    }
}