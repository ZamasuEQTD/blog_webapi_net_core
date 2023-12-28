namespace Shared.Archivos.Domain
{
  public abstract class ArchivoFisico : ArchivoTemplate
  {
      public string FileName {get;protected set;}
      public virtual string Extension {get;protected set;}
      protected ArchivoFisico(string fuente, bool esSpoiler,string fileName,string extension) : base(fuente, esSpoiler)
      {
        this.FileName = fileName;
        this.Extension = extension;
      }
      public override bool SoportaMiniatura()
      {
        return Fuente.Contains("video");
      }
      public override bool SoportaVistaPrevia()
      {
          return Fuente.Contains("video")  || Fuente.Contains("gif");
      }
      public bool EsPrimario() {
          return Fuente.Contains("video") || Fuente.Contains("gif")  || Fuente.Contains("image");
      }
      abstract public Task<Stream> GetStream();
  }

  public class MimeType
    {
        public string Mime{get;private set;}

        public MimeType(string mime)
        {
            Mime = mime;
        }
    }

}