using Core.Failures;

namespace Categorias.Domain
{
    static public class SubcategoriaFailures
    {
        static public readonly Failure NoEncontrado = new("Subcategoria.NoEncontrada");
        static public readonly Failure NombreFueraDeRango = new("FueraDeRango", "Debe tener entre 8 y 16 caracteres");
        static public readonly Failure NombreCortoFueraDeRango = new("Subcategoria.NombreCorto.FueraDeRango", "Debe tener entre 3 y 8 caracteres");
    }
}