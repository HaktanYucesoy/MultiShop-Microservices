using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiShop.Identity.Domain.Entities;

namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Configurations
{
    public class EmailAuthenticatorConfiguration : IEntityTypeConfiguration<EmailAuthenticator>
    {
        public void Configure(EntityTypeBuilder<EmailAuthenticator> builder)
        {
            builder.ToTable("EmailAuthenticators").HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
            builder.Property(r => r.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(r => r.IsVerified).HasColumnName("IsVerified").IsRequired();
            builder.Property(r => r.ActivationCode).HasColumnName("ActivationCode").IsRequired();
            builder.Property(r=>r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(r=>r.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(r=>!r.DeletedDate.HasValue);

            builder.HasOne(r => r.User);
        }
    }
}
