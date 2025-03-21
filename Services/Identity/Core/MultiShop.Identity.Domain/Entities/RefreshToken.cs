namespace MultiShop.Identity.Domain.Entities
{
    public class RefreshToken : BaseEntity<int>
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string? RevokedByIp { get; set; }
        public string? ReplacedByToken { get; set; }

        public virtual User User { get; set; } = null!;
        public bool IsActive => Revoked == null && !IsExpired;

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

    }
}
