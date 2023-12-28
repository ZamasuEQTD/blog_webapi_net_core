using Core.Failures;
using Media.Domain;
using Shared.Archivos.Domain;

namespace Media.Application
{
    public interface IMediaService {
        public Task<Failure> CrearArchivo(ArchivoFisico archivo,ArchivoEsperado archivoEsperado = ArchivoEsperado.Culquiera);
    }
    public class MediaService : IMediaService
    {
        public IMediaManager _mediaManager;

        public MediaService(IMediaManager mediaManager)
        {
            _mediaManager = mediaManager;
        }
        public async Task<Failure> CrearArchivo(ArchivoFisico archivo, ArchivoEsperado archivoEsperado = ArchivoEsperado.Culquiera)
        {
            if(archivoEsperado != ArchivoEsperado.Culquiera) {
                if(archivoEsperado == ArchivoEsperado.Primario && archivo.EsPrimario() && archivoEsperado == ArchivoEsperado.Secundario && !archivo.EsPrimario()) {
                    var archivoResult = await  _mediaManager.CrearReferenciaHaciaArchivo(archivo);
                    if(archivoResult.IsFailure) {       
                        return archivoResult.Error;
                    }
                } 
            }
            throw new NotImplementedException();
        }
    }
    public enum ArchivoEsperado {
        Primario,
        Secundario,
        Culquiera
    }
}