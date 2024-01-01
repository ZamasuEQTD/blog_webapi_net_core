using Core.Result;
using Shared.Archivos.Domain;
using Shared.Hasher;

namespace Medias.Domain
{
    public interface IMediaManager
    {
        public Task<Result<MediaReference>> CrearReferenciaHaciaArchivo(ArchivoFisico archivo);
        public Task<Result<MediaReference>> CrearReferenciaHaciaArchivo(ArchivoLink link);
    }

    class MediaManager : IMediaManager
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IArchivosHelper _archivosHelper;
        private readonly IVistaPreviaHelper _vistaPreviaHelper;
        private readonly IMiniaturaHelper _miniaturaHelper;
        private readonly IHasherHelper _hasherHelper;
        private readonly string _mediaFolder;

        public MediaManager(
            IMediaRepository mediaRepository,
            IArchivosHelper archivosHelper,
            IVistaPreviaHelper vistaPreviaHelper,
            IMiniaturaHelper miniaturaHelper,
            IHasherHelper hasherHelper,
            string mediaFolder
        )
        {
            Console.Write("       MediaFolder        " + mediaFolder);
            _mediaRepository = mediaRepository;
            _archivosHelper = archivosHelper;
            _vistaPreviaHelper = vistaPreviaHelper;
            _miniaturaHelper = miniaturaHelper;
            _hasherHelper = hasherHelper;
            _mediaFolder = mediaFolder;
        }
        public async Task<Result<MediaReference>> CrearReferenciaHaciaArchivo(ArchivoFisico archivo)
        {
            var stream = await archivo.GetStream();

            var hash = await _hasherHelper.HashStreamAsync(stream);

            var archivoExistente = await _mediaRepository.GetMediaByHash(hash);

            if (archivoExistente.IsSuccess)
            {
                var referenciaNueva = new MediaReference(MediaReferenceId.Nuevo(), archivoExistente.Value.Id, archivo.EsSpoiler);
                // await _mediaRepository.CrearMediaReference(referenciaNueva);
                return Result<MediaReference>.Success(referenciaNueva);

            }
            var absolutePath = await _archivosHelper.GuardarArchivoStream(stream, _mediaFolder, hash + archivo.Extension);

            if (archivo.SoportaVistaPrevia())
            {
                absolutePath = await _vistaPreviaHelper.GenerarVistaPreviaDesdeVideo(absolutePath);
            }

            await _miniaturaHelper.CrearMiniatura(absolutePath);

            var archivoNuevo = new MediaReference(MediaReferenceId.Nuevo(), new Media(MediaId.Nuevo(), hash, hash + archivo.Extension), archivo.EsSpoiler);

            return Result<MediaReference>.Success(archivoNuevo);
        }



        public Task<Result<MediaReference>> CrearReferenciaHaciaArchivo(ArchivoLink link)
        {

            throw new NotImplementedException();
        }

        private async Task CrearImagenesDeArchivo(string absolutePath)
        {
        }
    }
}