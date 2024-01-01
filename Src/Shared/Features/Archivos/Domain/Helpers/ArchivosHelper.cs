namespace Shared.Archivos.Domain
{
    public interface IArchivosHelper {
        public Task<Stream> CrearStreamFromFile(string path);
        public Task<string> GuardarArchivoStream(Stream stream, string outputFolder,string? fileName  = null);
    }
    class ArchivosHelper : IArchivosHelper
    {
        public Task<Stream> CrearStreamFromFile(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GuardarArchivoStream(Stream stream, string outputFolder, string fileName)
        {
            stream.Seek(0,SeekOrigin.Begin);
            // Combina la ruta de la subcarpeta y el nombre del archivo
            string filePath = Path.Combine(outputFolder, fileName);
            // Crea un stream a partir de la ruta del archivo
            using (FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write))
            {
                // Copia el contenido del IFormFile al stream
                await stream.CopyToAsync(fileStream);
                await fileStream.DisposeAsync();
            }
            // Retorna la ruta del archivo
            return filePath;
        }

    }

     
}