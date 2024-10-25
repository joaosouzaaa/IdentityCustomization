using IdentityCustomization.API.Constants;
using IdentityCustomization.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityCustomization.API.Data.EntitiesMapping;

internal sealed class UserClaimMapping : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable(TableNamesConstants.UserClaimTableName, SchemaNamesConstants.IdentitySchema);

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .IsRequired(true)
            .HasColumnName("id");

        builder.Property(u => u.UserId)
            .IsRequired(true)
            .HasColumnName("user_id");

        builder.Property(u => u.ClaimType)
            .IsRequired(false)
            .HasColumnType("varchar(255)")
            .HasColumnName("claim_type");

        builder.Property(u => u.ClaimValue)
            .IsRequired(false)
            .HasColumnType("varchar(255)")
            .HasColumnName("claim_value");
    }
}
