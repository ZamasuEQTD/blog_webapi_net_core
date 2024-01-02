using Categorias.Domain;
using Encuestas.Domain;
using Medias.Domain;
using Users.Domain;

namespace Hilos.Domain
{
    public record CrearHiloForm(
    UserId User,
    TituloDeHilo Titulo,
    DescripcionDeHilo Descripcion,
    MediaReference Media,
    SubcategoriaId SubcategoriaId,
    BanderasDeHilo Banderas,
    Encuesta? Encuesta
    );
}