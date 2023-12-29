namespace Auth.Application
{
    public class LoginDto
    {
        public string UserName {get;private set;}
        public string Password {get;private set;}

        public LoginDto(string userName,string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

    }
}