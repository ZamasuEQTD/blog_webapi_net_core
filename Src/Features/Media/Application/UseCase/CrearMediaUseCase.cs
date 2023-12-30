using Core.Result;
using Medias.Domain;
using Shared.Archivos.Domain;

namespace Medias.Application
{
    public class CrearMediaUseCase
    {
        public IMediaManager _mediaManager;
        public async Task<Result<MediaReference>> Execute(ArchivoFisico archivo, ArchivoEsperado? archivoEsperado = ArchivoEsperado.Culquiera)
        {
            if (archivoEsperado != ArchivoEsperado.Culquiera)
            {
                if (archivoEsperado == ArchivoEsperado.Primario && archivo.EsPrimario() || archivoEsperado == ArchivoEsperado.Secundario && !archivo.EsPrimario())
                {
                    return Result<MediaReference>.Failure(new("No corresponde con archivo esperado"));
                }
            }

            return await _mediaManager.CrearReferenciaHaciaArchivo(archivo);
        }
    }

    public enum ArchivoEsperado
    {
        Primario,
        Secundario,
        Culquiera
    }
}