using MultiShop.Identity.Application.Interfaces.Repositories.OperationClaim;
using MultiShop.Identity.Domain.Entities;


namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Repositories
{
    public class OperationClaimEfCoreRepository : BaseEntityFrameworkCoreRepository<OperationClaim>,
                IOperationClaimRepository
    {
        public OperationClaimEfCoreRepository(MultiShopIdentityContext dbContext) : base(dbContext)
        {
        }
    }
}
