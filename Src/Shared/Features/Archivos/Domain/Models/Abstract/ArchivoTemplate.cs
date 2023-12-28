namespace Shared.Archivos.Domain
{
    public abstract class ArchivoTemplate{
        public bool EsSpoiler { get; protected set; }
        public string Fuente {get;protected set;}
        
        protected ArchivoTemplate(string fuente, bool esSpoiler)
        {
            Fuente = fuente;
            EsSpoiler = esSpoiler;
        }
        
        public  abstract bool  SoportaVistaPrevia();   
        public  abstract bool  SoportaMiniatura();     
    }
    
}