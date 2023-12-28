using Core.Failures;

namespace Hilos.Domain
{
    static public class HiloFailures
    {
         public static readonly Failure HiloInexistenteNoEncontrado = new Failure("Hilos.NoEncontrado", "Hilo inexistente o no encontrado");
        public static readonly Failure SinTitulo = new Failure("Hilos.SinTitulo", "Titulo vacio");
        public static readonly Failure SinDescripcion = new Failure("Hilos.SinDescripcion", "Descripcion vacia");
        public static readonly Failure LargoDeTituloFueraDeRango = new Failure("Hilos.TituloFueraDeRango", "El titulo debe tener entre 10 y 120 caracteres");
        public static readonly Failure LargoDeDescripcionFueraDeRango = new Failure("Hilos.TituloFueraDeRango", "La descripcion debe tener entre 10 y 200 caracteres");
        public static readonly Failure NoActivo = new Failure("Hilos.NoActivo", "Hilo no activo");

    }
}