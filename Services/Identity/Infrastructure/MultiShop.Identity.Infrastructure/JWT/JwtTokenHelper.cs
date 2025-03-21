using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MultiShop.Identity.Application.Interfaces.TokenHelper;
using MultiShop.Identity.Domain.Entities;
using MultiShop.Identity.Domain.ValueObjects;
using MultiShop.Identity.Infrastructure.Encryption;
using MultiShop.Identity.Infrastructure.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MultiShop.Identity.Infrastructure.JWT
{
    public class JwtTokenHelper : ITokenHelper
    {

        private readonly TokenOptions _tokenOptions;
        private IConfiguration _configuration;
        private DateTime _accessTokenExpiration;

        public JwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            const string tokenOptionsString = "TokenOptions";
            _tokenOptions = _configuration.GetSection(tokenOptionsString)
                .Get<TokenOptions>() ??
                throw new NullReferenceException($"\"{tokenOptionsString}\" section cannot found in configuration");
        }
        public AccessToken CreateAccessToken(User user, IList<OperationClaim> operationClaims)
        {
            _accessTokenExpiration=DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            JwtSecurityToken jwtSecurityToken = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

            var token=jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new AccessToken()
            {
                Token = token,
                Expiration = _accessTokenExpiration,
            };
        }

        public RefreshToken CreateRefreshToken(User user, string ipAddress, int addedExpireDayNumber)
        {
            RefreshToken refreshToken = new RefreshToken()
            {
                UserId = user.Id,
                CreatedByIp = ipAddress,
                Expires = DateTime.Now.AddDays(addedExpireDayNumber),
                Token = RandomRefreshToken()
            };

            return refreshToken;
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,
            User user,
            SigningCredentials signingCredentials,
            IList<OperationClaim> operationClaims)
        {
            JwtSecurityToken jwtSecurityToken=new JwtSecurityToken(
                tokenOptions.Issuer,tokenOptions.Auidence,
                SetClaims(user, operationClaims),DateTime.Now,
                _accessTokenExpiration,signingCredentials);

            return jwtSecurityToken;
        }


        private IEnumerable<Claim> SetClaims(User user,IList<OperationClaim> operationClaims)
        {
            List<Claim> claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName(user.FullName);
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(x=>x.Name).ToArray());
            return claims;
        }

        private string RandomRefreshToken()
        {
            byte[] numberByte=new byte[32];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
    }
}
