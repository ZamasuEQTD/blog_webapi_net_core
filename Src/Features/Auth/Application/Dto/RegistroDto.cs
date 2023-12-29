namespace Auth.Application
{
    public class RegistroDto
    {
        public string UserName {get;set;}
        public string Password {get;set;}
        public string PasswordRepetida {get;set;}

        public RegistroDto(string userName,string password,string passwordRepetida)
        {
            this.UserName = userName;
            this.Password = password;
            this.PasswordRepetida = passwordRepetida;
        }
    }
}