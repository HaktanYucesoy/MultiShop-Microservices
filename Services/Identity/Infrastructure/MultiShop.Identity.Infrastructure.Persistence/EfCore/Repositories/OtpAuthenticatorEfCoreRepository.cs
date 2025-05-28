using MultiShop.Identity.Application.Interfaces.Repositories.OtpAuthenticator;
using MultiShop.Identity.Domain.Entities;

namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Repositories
{
    public class OtpAuthenticatorEfCoreRepository : BaseEntityFrameworkCoreRepository<OtpAuthenticator>,
        IOtpAuthenticatorRepository
    {
        public OtpAuthenticatorEfCoreRepository(MultiShopIdentityContext dbContext) : base(dbContext)
        {
        }
    }
}
