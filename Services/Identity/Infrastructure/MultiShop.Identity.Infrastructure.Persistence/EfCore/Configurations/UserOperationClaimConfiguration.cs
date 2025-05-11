using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiShop.Identity.Domain.Entities;

namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Configurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").HasKey(uo => uo.Id);

            builder.Property(uo => uo.Id).HasColumnName("Id").IsRequired();
            builder.Property(uo=>uo.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(uo => uo.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

            builder.Property(uo=>uo.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(uo => uo.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(uo=>uo.DeletedDate).HasColumnName("DeletedDate");

            builder.HasQueryFilter(uo=>!uo.DeletedDate.HasValue);

            builder.HasOne(uo => uo.User);
            builder.HasOne(uo => uo.OperationClaim);


        }
    }
}
