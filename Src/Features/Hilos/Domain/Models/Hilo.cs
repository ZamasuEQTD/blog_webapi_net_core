using Categorias.Domain;
using Encuestas.Domain;
using Medias.Domain;
using Users.Domain;

namespace Hilos.Domain
{
    public class Hilo
    {
        public HiloId Id { get; private set; }
        public UserId AutorId { get; private set; }
        public User Autor { get; private set; }
        public MediaReferenceId MediaId { get; private set; }
        public MediaReference Media { get; private set; }
        public TituloDeHilo Titulo { get; private set; }
        public DescripcionDeHilo Descripcion { get; private set; }
        public EncuestaId? EncuestaId { get; private set; }
        public Encuesta? Encuesta { get; private set; }

        private Hilo() { }
        public Hilo(
            HiloId id,
            User autor,
            MediaReference media,
            TituloDeHilo titulo,
            DescripcionDeHilo descripcion,
            Encuesta? encuesta
        )
        {
            Id = id;
            Autor = autor;
            Media = media;
            Descripcion = descripcion;
            Encuesta = encuesta;
            Titulo = titulo;
        }
    }
}