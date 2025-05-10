namespace MultiShop.Identity.Domain.Entities
{
    public class RefreshToken : BaseEntity<int>
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsRevoked => Revoked != null;
        public bool IsActive => !IsRevoked && !IsExpired;
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string? RevokedByIp { get; set; }
        public string? ReplacedByToken { get; set; }
        public string? ReasonRevoked { get; set; }

        public virtual User User { get; set; } = null!;

        public RefreshToken()
        {
            Token = String.Empty;
            CreatedByIp = String.Empty;
        }

        public RefreshToken(string token,DateTime expires,string createdByIp)
        {
            Token = token;
            Expires = expires;
            CreatedByIp = createdByIp;
            Expires = expires;
        }

        public RefreshToken(int id, string token, DateTime expires, DateTime created, string createdByIp, DateTime? revoked,
                       string revokedByIp, string replacedByToken, string reasonRevoked)
        {
            Id = id;
            Token = token;
            Expires = expires;
            CreatedDate = created;
            CreatedByIp = createdByIp;
            Revoked = revoked;
            RevokedByIp = revokedByIp;
            ReplacedByToken = replacedByToken;
            ReasonRevoked = reasonRevoked;
        }

    }
}
