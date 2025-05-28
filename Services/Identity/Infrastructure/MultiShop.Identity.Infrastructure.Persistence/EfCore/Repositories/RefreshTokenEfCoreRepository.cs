using MultiShop.Identity.Application.Interfaces.Repositories.RefreshToken;
using MultiShop.Identity.Domain.Entities;


namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Repositories
{
    public class RefreshTokenEfCoreRepository : BaseEntityFrameworkCoreRepository<RefreshToken>,
       IRefreshTokenRepository
    {
        public RefreshTokenEfCoreRepository(MultiShopIdentityContext dbContext) : base(dbContext)
        {
        }
    }
}
