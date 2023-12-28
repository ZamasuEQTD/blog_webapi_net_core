using Shared.Archivos.Domain;

namespace Media.Application
{
    public class IFormMediaFile : ArchivoFisico
    {
        public IFormFile File;
        private  IFormMediaFile(string fuente, bool esSpoiler, string fileName, string extension,IFormFile file) : base(fuente, esSpoiler, fileName, extension)
        {
            this.File = file;
        }

        public IFormMediaFile Create(IFormFile file,bool esSpoiler){
            var extension = Path.GetExtension(file.FileName);
            return new IFormMediaFile(file.ContentType,esSpoiler,file.FileName,extension,file);
        }
        public  async override Task<Stream> GetStream()
        {
           return this.File.OpenReadStream();
        }
    }
}