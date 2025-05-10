
using MultiShop.Identity.Domain.Enums;

namespace MultiShop.Identity.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public User(string userName, string firstName, string lastName, byte[] passwordHash, byte[] passwordSalt, bool status)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{FirstName} {LastName}";
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Status = status;
        }

        public User()
        {
            UserName = String.Empty;
            FirstName=String.Empty;
            LastName=String.Empty;
            FullName=String.Empty;
            PasswordHash=Array.Empty<byte>();
            PasswordSalt=Array.Empty<byte>();
            Status = false;
        }

        public User(int id, string userName, string firstName, string lastName, byte[] passwordHash, byte[] passwordSalt, bool status)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{FirstName} {LastName}";
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Status = status;
        }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool Status { get; set; }

        public AuthenticatorType AuthenticatorType { get; set; }
        public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = null!;
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = null!;
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = null!;

        public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = null!;
        public string Email { get; set; }
    }
}
