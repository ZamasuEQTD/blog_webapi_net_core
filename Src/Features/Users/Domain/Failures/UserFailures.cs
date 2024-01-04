using Core.Failures;

namespace Users.Domain
{
    
    static public class UserFailures
    {
        static public readonly Failure NoEncontrado = new("Usuario.NoEncontrado", "Usuario inexistente");
    }
}