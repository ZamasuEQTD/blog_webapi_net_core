using Core.Failures;

namespace Auth.Domain
{
    static public  class AuthFailures
    {
        static public readonly Failure UsuarioExistente = new Failure("Auth.UsuarioYaRegistrado", "Usuario ya existente");
        static public readonly Failure PasswordsNoCoincidientes = new Failure("Auth.UsuarioYaRegistrado", "Usuario ya existente");
        static public readonly Failure UsuarioPasswordIncorrecto = new Failure("Auth.UsuarioNoCoinciendientePasswordIncorrecta", "Usuario ya existente");
        
        
    }
}