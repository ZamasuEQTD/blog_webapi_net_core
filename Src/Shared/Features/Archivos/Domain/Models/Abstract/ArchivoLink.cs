using Shared.Youtube.Domain;

namespace Shared.Archivos.Domain
{
    public abstract class ArchivoLink : ArchivoTemplate
    {

        protected ArchivoLink(string fuente, bool esSpoiler) : base(fuente, esSpoiler)
        {
            
        }
    }
}
