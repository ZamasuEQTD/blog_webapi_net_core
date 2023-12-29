namespace Users.Domain
{
    public class HashedPassword
    {
        public string Value { get; private set; }

        public HashedPassword(string value)
        {
            Value = value;
        }
    }
}