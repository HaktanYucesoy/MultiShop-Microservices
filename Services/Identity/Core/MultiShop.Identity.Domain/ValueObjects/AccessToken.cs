
namespace MultiShop.Identity.Domain.ValueObjects
{
    public class AccessToken
    {
        public string Token { get; set; }

        public DateTime Expiration {  get; set; }

        public AccessToken()
        {
            Token=String.Empty;
        }

        public AccessToken(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }
}
