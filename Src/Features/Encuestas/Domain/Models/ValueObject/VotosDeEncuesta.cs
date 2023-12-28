using Core.Failures;
using Core.Result;

namespace Encuestas.Domain
{
    public class VotosDeEncuesta
    {
        public int Value {get;private set;}

        private VotosDeEncuesta(int value)
        {
            this.Value = value;
        }
        static public Result<VotosDeEncuesta> Create(int votos) {
            if(votos < 0)  {
                return Result<VotosDeEncuesta>.Failure( new Failure("Votos invalidos, no pueden ser menores a 0"));
            }
            return Result<VotosDeEncuesta>.Success(new VotosDeEncuesta(votos));
        }
    }
}