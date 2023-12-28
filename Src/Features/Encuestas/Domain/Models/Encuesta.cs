namespace Encuestas.Domain
{
    public sealed class Encuesta{
        public EncuestaId  Id {get;private set;}
        public List<EncuestaOpcion> Opciones {get;private set;}
        private Encuesta() {} 
        public Encuesta(EncuestaId id,List<EncuestaOpcion> opciones)
        {
            this.Id = id;
            this.Opciones = opciones;
        }
    }
}