namespace Shared.Archivos.Domain
{
    public interface IArchivosHelper
    {
        public Task<Stream> CrearStreamFromFile(string path);
        public Task<string> GuardarArchivoStream(Stream stream, string outputFolder, string? fileName = null);
    }
    class ArchivosHelper : IArchivosHelper
    {
        public async Task<Stream> CrearStreamFromFile(string path)
        {
            var miniaturaStream = File.OpenRead(path);
            // Crea un nuevo stream de memoria para copiar el contenido
            Stream copiaStream = new MemoryStream();
            await miniaturaStream.CopyToAsync(copiaStream);
            // Establece la posición del nuevo stream a cero
            copiaStream.Seek(0, SeekOrigin.Begin);
            // Cierra y elimina el stream original
            // Devuelve el stream copiado
            return copiaStream;
        }

        public async Task<string> GuardarArchivoStream(Stream stream, string outputFolder, string fileName)
        {
            stream.Seek(0, SeekOrigin.Begin);
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