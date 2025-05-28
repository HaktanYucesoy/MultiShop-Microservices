using MultiShop.Identity.Application.Interfaces.Repositories.UserOperationClaim;
using MultiShop.Identity.Domain.Entities;


namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Repositories
{
    public class UserOperationClaimEfCoreRepository : BaseEntityFrameworkCoreRepository<UserOperationClaim>,
        IUserOperationClaimRepository
    {
        public UserOperationClaimEfCoreRepository(MultiShopIdentityContext dbContext) : base(dbContext)
        {
        }
    }
}
