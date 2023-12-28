using Core.Failures;

namespace Encuestas.Domain
{
    static public class EncuestaFailures {
        static public readonly Failure NoSuperaCantidadMinimaDeOpciones = new Failure("Debe haber al menos 2 opciones");
        static public readonly Failure SuperaCantidadMaximaDeOpciones = new Failure("Debe haber hasta 5 opciones");
        static public readonly Failure OpcionVacia = new Failure("");
        static public readonly Failure LargoDeOpcionInvalido = new Failure("");
    } 
}