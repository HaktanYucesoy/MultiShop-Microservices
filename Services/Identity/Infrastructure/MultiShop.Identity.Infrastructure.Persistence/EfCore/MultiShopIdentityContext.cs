using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiShop.Identity.Domain.Entities;
using MultiShop.Identity.Infrastructure.Persistence.EfCore.Configurations;

namespace MultiShop.Identity.Infrastructure.Persistence.EfCore
{
    public class MultiShopIdentityContext:DbContext
    {
        protected IConfiguration _configuration { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }

        public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
        public MultiShopIdentityContext(DbContextOptions<MultiShopIdentityContext> dbContextOptions,IConfiguration configuration):base(dbContextOptions)
        {
            _configuration=configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }



    }
}
