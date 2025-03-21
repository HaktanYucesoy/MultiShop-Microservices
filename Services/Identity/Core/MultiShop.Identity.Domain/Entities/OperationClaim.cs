
namespace MultiShop.Identity.Domain.Entities
{
    public class OperationClaim:BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = null!;

        public OperationClaim()
        {
            
            Name = string.Empty;
        }

        public OperationClaim(string name)
        {
            
            Name = name;
        }

        public OperationClaim(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
