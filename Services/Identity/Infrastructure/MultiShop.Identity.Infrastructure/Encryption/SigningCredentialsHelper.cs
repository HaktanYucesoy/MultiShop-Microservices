using Microsoft.IdentityModel.Tokens;

namespace MultiShop.Identity.Infrastructure.Encryption
{
    public static class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) => new(securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
}
