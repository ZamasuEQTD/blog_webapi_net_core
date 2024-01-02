using Core.Result;

namespace Hilos.Domain
{
    public class DescripcionDeHilo
    {
        private const int MaxLenght = 150;
        private const int MinLenght = 10;
        public string Value { get; private set; }
        private DescripcionDeHilo() { }
        private DescripcionDeHilo(string Descripcion)
        {
            Value = Descripcion;
        }

        static public Result<DescripcionDeHilo> Create(string descripcion)
        {

            if (descripcion.Length == 0)
            {
                return Result<DescripcionDeHilo>.Failure(HiloFailures.SinDescripcion);
            }
            int Length = descripcion.Length;
            if (Length > MaxLenght || Length < MinLenght)
            {
                return Result<DescripcionDeHilo>.Failure(HiloFailures.LargoDeDescripcionFueraDeRango);
            }
            return Result<DescripcionDeHilo>.Success(new DescripcionDeHilo(descripcion));
        }

    }
}