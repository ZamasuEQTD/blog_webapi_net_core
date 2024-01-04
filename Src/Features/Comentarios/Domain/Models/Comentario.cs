using Hilos.Domain;
using Medias.Domain;
using Shared.Common.Domain;
using Users.Domain;

namespace Comentarios.Domain
{
 public  sealed class Comentario:CreacionDeUsuario
 {
    public ComentarioId Id {get;private set;} = new (Guid.NewGuid());
    public TextoDeComentario Texto {get; private set;}
    public HiloId HiloId {get;private set;}
    public Hilo Hilo {get;private set;}
    public DatosDeComentario DatosDeComentario {get;private set;}
    public MediaReference? Media {get;private set;}
    public MediaReferenceId? MediaId {get;private set;}

    private Comentario(){}
    public Comentario(User autor,Hilo hilo, TextoDeComentario texto,DatosDeComentario datosDeComentario, MediaReference? media) : base( autor)
    {
      Hilo = hilo;
      Texto = texto;
      DatosDeComentario = datosDeComentario;
      Media = media;
    }
 }   
}