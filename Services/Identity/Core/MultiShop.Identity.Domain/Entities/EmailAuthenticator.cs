
namespace MultiShop.Identity.Domain.Entities
{
    public class EmailAuthenticator:BaseEntity<int>
    {
        public int UserId { get; set; }

        public string? ActivationCode { get; set; }

        public bool IsVerified { get; set; }


        public virtual User User { get; set; } = null!;


        public EmailAuthenticator() { }


        public EmailAuthenticator(int userId, string activationCode, bool isVerified)
        {
            UserId = userId;
            ActivationCode = activationCode;
            IsVerified = isVerified;
        }

        public EmailAuthenticator(int userId,bool isVerified)
        {
            UserId = userId;
            IsVerified = isVerified;
        }
    }
}
