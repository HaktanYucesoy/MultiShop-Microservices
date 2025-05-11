using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiShop.Identity.Domain.Entities;


namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
            builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
            builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
            builder.Property(u => u.Status).HasColumnName("Status").HasDefaultValue(true);
            builder.Property(u => u.FullName).HasColumnName("FullName").IsRequired();
            builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").HasDefaultValue(DateTime.Now);
            builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");

            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

            builder.HasMany(u => u.RefreshTokens);
            builder.HasMany(u => u.OtpAuthenticators);
            builder.HasMany(u => u.EmailAuthenticators);
            builder.HasMany(u=>u.UserOperationClaims);

           
           
        }

      
    }
}
