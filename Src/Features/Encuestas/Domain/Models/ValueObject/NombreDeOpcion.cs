using Core.Result;

namespace Encuestas.Domain
{
    public record NombreDeOpcion
    {
        private const int MinLength = 10;
        private const int MaxLength = 50;
        public string Value { get;private set; }
        private NombreDeOpcion() { }
        private NombreDeOpcion(string nombreDeOpcion)
        {
            Value = nombreDeOpcion;
        }

        static public Result<NombreDeOpcion> Create(string nombreDeOpcion)
        {
            if (nombreDeOpcion.Length == 0)
            {
                Result<NombreDeOpcion>.Failure(EncuestaFailures.OpcionVacia);
            }
            if (!LargoValido(nombreDeOpcion))
            {
                Result<NombreDeOpcion>.Failure(EncuestaFailures.LargoDeOpcionInvalido);
            }

            return Result<NombreDeOpcion>.Success(new NombreDeOpcion(nombreDeOpcion));
        }

        static private bool LargoValido(string nombre)
        {
            return !(nombre.Length > MaxLength || nombre.Length < MinLength);
        }
    }
}
