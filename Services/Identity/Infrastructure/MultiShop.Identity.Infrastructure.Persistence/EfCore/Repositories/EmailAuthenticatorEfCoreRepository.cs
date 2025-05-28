using MultiShop.Identity.Application.Interfaces.Repositories.EmailAuthenticator;
using MultiShop.Identity.Domain.Entities;


namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Repositories
{
    public class EmailAuthenticatorEfCoreRepository : BaseEntityFrameworkCoreRepository<EmailAuthenticator>,
        IEmailAuthenticatorRepository
    {
        public EmailAuthenticatorEfCoreRepository(MultiShopIdentityContext dbContext) : base(dbContext)
        {
        }
    }
}
