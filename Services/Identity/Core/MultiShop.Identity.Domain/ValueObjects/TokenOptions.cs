
namespace MultiShop.Identity.Domain.ValueObjects
{
    public class TokenOptions
    {

        public TokenOptions()
        {
            Auidence=String.Empty;
            Issuer=String.Empty;
            SecurityKey=String.Empty;
        }
        public TokenOptions(string auidence, string issuer, int accessTokenExpiration, string securityKey, int refreshTokenTTL)
        {
            Auidence = auidence;
            Issuer = issuer;
            AccessTokenExpiration = accessTokenExpiration;
            SecurityKey = securityKey;
            RefreshTokenTTL = refreshTokenTTL;
        }

        public string Auidence { get; set; }

        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; }

        public string SecurityKey { get; set; }

        public int RefreshTokenTTL { get; set; }


    }
}
