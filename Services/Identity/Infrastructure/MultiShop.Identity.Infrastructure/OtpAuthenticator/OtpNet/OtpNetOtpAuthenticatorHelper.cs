using MultiShop.Identity.Application.Interfaces.OtpAuthenticator;
using OtpNet;

namespace MultiShop.Identity.Infrastructure.OtpAuthenticator.OtpNet
{
    public class OtpNetOtpAuthenticatorHelper : IOtpAuthenticatorHelper
    {
        public Task<string> ConvertSecretKeyToString(byte[] secretKey)
        {
           string base32String=Base32Encoding.ToString(secretKey);
           return Task.FromResult(base32String);
        }

        public Task<byte[]> GenerateSecretKey()
        {
            byte[] key = KeyGeneration.GenerateRandomKey(20);
            string base32String = Base32Encoding.ToString(key);
            byte[] base32Bytes = Base32Encoding.ToBytes(base32String);

            return Task.FromResult(base32Bytes);
        }

        public Task<bool> VerifyCode(byte[] secretKey, string code)
        {
            Totp toptp = new(secretKey);
            string toptpCode = toptp.ComputeTotp();
            bool result = toptpCode==code;

            return Task.FromResult(result);
        }
    }
}
