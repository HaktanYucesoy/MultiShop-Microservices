using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiShop.Identity.Domain.Entities;


namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Configurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims").HasKey(o => o.Id);

            builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
            builder.Property(o => o.Name).HasColumnName("Name").IsRequired();
            builder.Property(o=>o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

            builder.HasMany(o => o.UserOperationClaims);
        }
    }
}
