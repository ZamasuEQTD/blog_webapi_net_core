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
        public DateTime CreatedAt { get; private set; } = DateTime.Now.ToUniversalTime();
        public MediaReferenceId MediaId { get; private set; }
        public MediaReference Media { get; private set; }
        public SubcategoriaId SubcategoriaId { get; private set; }
        public Subcategoria Subcategoria { get; private set; }
        public TituloDeHilo Titulo { get; private set; }
        public DescripcionDeHilo Descripcion { get; private set; }
        public BanderasDeHilo Banderas { get; private set; }
        public EncuestaId? EncuestaId { get; private set; }
        public Encuesta? Encuesta { get; private set; }
        private Hilo() { }
        public Hilo(
            HiloId id,
            SubcategoriaId subcategoriaId,
            User autor,
            MediaReference media,
            TituloDeHilo titulo,
            DescripcionDeHilo descripcion,
            BanderasDeHilo banderas,
            Encuesta? encuesta
        )
        {
            Id = id;
            SubcategoriaId = subcategoriaId;
            Autor = autor;
            Media = media;
            Descripcion = descripcion;
            Banderas = banderas;
            Encuesta = encuesta;
            Titulo = titulo;
        }
    }
}