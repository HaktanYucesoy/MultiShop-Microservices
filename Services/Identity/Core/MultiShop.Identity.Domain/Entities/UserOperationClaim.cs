namespace MultiShop.Identity.Domain.Entities
{
    public class UserOperationClaim:BaseEntity<int>
    {
        public UserOperationClaim(int userId, int operationClaimId)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }

        public UserOperationClaim()
        {
          
        }

        public int UserId { get; set; }

        public int OperationClaimId { get; set; }

       

        public virtual User User { get; set; }

        public virtual OperationClaim OperationClaim { get; set; }


    }
}