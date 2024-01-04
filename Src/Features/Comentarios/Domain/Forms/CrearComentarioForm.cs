using Hilos.Domain;
using Medias.Domain;
using Users.Domain;

namespace Comentarios.Domain
{
    public record CrearComentarioForm(User Usuario,Hilo Hilo, TextoDeComentario TextoDeComentario,MediaReference? Media);
}