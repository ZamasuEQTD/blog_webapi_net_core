namespace Comentarios.Domain
{
    public interface ITagHelper {
        public TagDeComentario CrearTag();
        public TagUnico CrearTagUnico(string seed);

    }
}