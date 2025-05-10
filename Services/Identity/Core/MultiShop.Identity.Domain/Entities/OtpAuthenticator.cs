
namespace MultiShop.Identity.Domain.Entities
{
    public class OtpAuthenticator : BaseEntity<int>
    {

        public int UserId { get; set; }
        public byte[] SecretKey { get; set; }
        public bool IsVerified { get; set; }
      
        public virtual User User { get; set; } = null!;
        public OtpAuthenticator()
        {
            SecretKey = Array.Empty<byte>();
        }

        public OtpAuthenticator(int userId, byte[] secretKey, bool isVerified)
        {
            UserId = userId;
            SecretKey = secretKey;
            IsVerified = isVerified;
        }
    }
}
