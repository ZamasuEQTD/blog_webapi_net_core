namespace Users.Domain
{
    public sealed class User 
    {

        public UserId Id {get; private set;}
        public UserName UserName { get; private set; }
        public string Password { get; private set; }
        public Rango Rango { get; private set; }
        private User() { }
        public User(UserId id, UserName userName, string password, Rango rango) 
        {
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