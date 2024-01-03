namespace Users.Domain
{
    public sealed class User
    {

        public UserId Id { get; private set; }
        public UserName UserName { get; private set; }
        public HashedPassword Password { get; private set; }
        public Rango Rango { get; private set; }
        private User() { }
        public User(UserId id, UserName userName, HashedPassword password, Rango rango)
        {
            this.Id = id;
            this.UserName = userName;
            this.Password = password;
            this.Rango = rango;
        }

        public bool TienePrivilegios()
        {
            return Rango == Rango.Moderador || Rango == Rango.Owner;
        }
    }

    public enum Rango
    {
        Usuario,
        Jainator,
        Moderador,
        Owner
    }
}