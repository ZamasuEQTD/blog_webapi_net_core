using Core.Result;

namespace Hilos.Domain
{
    public record class TituloDeHilo
    {

        public const int MinLenght = 8;
        public const int MaxLenght = 150;
        public string Value { get; private set; }

        private TituloDeHilo() { }
        private TituloDeHilo(string titulo)
        {
            Value = titulo;
        }

        static public Result<TituloDeHilo> Create(string titulo)
        {

            if (titulo.Length == 0)
            {
                return Result<TituloDeHilo>.Failure(HiloFailures.SinTitulo);
            }
            int Length = titulo.Length;
            if (Length > MaxLenght || Length < MinLenght)
            {
                return Result<TituloDeHilo>.Failure(HiloFailures.LargoDeTituloFueraDeRango);
            }
            return Result<TituloDeHilo>.Success(new TituloDeHilo(titulo));
        }
    }
}