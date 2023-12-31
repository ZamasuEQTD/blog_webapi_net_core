namespace Encuestas.Domain
{
    public record EncuestaId
    {
        public Guid Value { get; private set; }

        public EncuestaId() { }
        public EncuestaId(Guid id)
        {
            Value = id;
        }


    }
}