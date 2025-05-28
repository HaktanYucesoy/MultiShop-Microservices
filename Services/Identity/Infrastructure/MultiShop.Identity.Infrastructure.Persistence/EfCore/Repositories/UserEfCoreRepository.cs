using MultiShop.Identity.Application.Interfaces.Repositories.User;
using MultiShop.Identity.Domain.Entities;


namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Repositories
{
    public class UserEfCoreRepository : BaseEntityFrameworkCoreRepository<User>,
        IUserRepository
    {
        public UserEfCoreRepository(MultiShopIdentityContext dbContext) : base(dbContext)
        {
        }
    }
}
