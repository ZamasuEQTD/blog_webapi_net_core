using Encuestas.Domain;
using Users.Domain;

namespace Hilos.Domain
{
    public record CrearHiloForm(UserId User,TituloDeHilo Titulo,DescripcionDeHilo Descripcion,Encuesta? Encuesta);
}