namespace Encuestas.Domain
{
    public class EncuestaOpcion
    {
        public EncuestaOpcionId Id { get; private set; }
        public EncuestaId EncuestaId { get; private set; }
        public NombreDeOpcion Nombre { get; private set; }
        public VotosDeEncuesta Votos { get; private set; }
        private EncuestaOpcion()
        {

        }

        public EncuestaOpcion(EncuestaOpcionId id, EncuestaId encuestaId, NombreDeOpcion nombreDeOpcion, VotosDeEncuesta votos)
        {
            Id = id;
            EncuestaId = encuestaId;
            Nombre = nombreDeOpcion;
            Votos = votos;
        }

        public void SumarVoto()
        {
            this.Votos = VotosDeEncuesta.Create(this.Votos.Value).Value;
        }
    }
}