using Core.Result;

namespace Encuestas.Domain
{
    public sealed class OpcionesDeEncuesta
    {
        static public readonly int CantidadMaximaDeOpciones = 5;
        static public readonly int CantidadMinimaDeOpciones = 2;
        public List<NombreDeOpcion>Value {get;private set;}
        public OpcionesDeEncuesta(List<NombreDeOpcion> value)
        {
            Value = value;
        }
        static public Result<OpcionesDeEncuesta> Create(List<string>opciones) {
            if(opciones.Count > CantidadMaximaDeOpciones ) {
                return Result<OpcionesDeEncuesta>.Failure(EncuestaFailures.SuperaCantidadMaximaDeOpciones);
            }
            if(opciones.Count < CantidadMinimaDeOpciones) {
                return Result<OpcionesDeEncuesta>.Failure(EncuestaFailures.NoSuperaCantidadMinimaDeOpciones);
            }
            List<NombreDeOpcion> encuesta = new (); 
            foreach (var item in opciones)
            {
               var result =  NombreDeOpcion.Create(item);
                if(result.IsFailure) {
                    return Result<OpcionesDeEncuesta>.Failure(result.Error);
                }
                encuesta.Add(result.Value);
            }
            return Result<OpcionesDeEncuesta>.Success(new OpcionesDeEncuesta(encuesta));
        }
    }
}