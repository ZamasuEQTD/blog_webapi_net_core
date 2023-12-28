namespace Media.Domain
{

    public record class MediaId  
    {
        public Guid Value { get; private set; }

        public MediaId() { }
        public MediaId(Guid id)
        {
            Value = id;
        }
        static public MediaId Nuevo(){
            return new MediaId(Guid.NewGuid());
        }
    }
}