namespace Auth.Application
{
    public class TokenDto
    {
        public string Token {get;private set;}
        public string RefreshToken {get;private set;}

        public TokenDto(string token,string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}