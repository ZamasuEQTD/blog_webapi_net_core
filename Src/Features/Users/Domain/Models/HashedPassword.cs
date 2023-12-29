namespace Users.Domain
{
    public class HashedPassword
    {
        public string Value { get; private set; }

        private HashedPassword(string value)
        {
            Value = value;
        }
    }
}