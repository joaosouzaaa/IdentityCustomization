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

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .IsRequired(true)
            .HasColumnName("id");

        builder.Property(a => a.UserId)
            .IsRequired(true)
            .HasColumnName("user_id");

        builder.Property(a => a.ClaimType)
            .IsRequired(false)
            .HasColumnType("varchar(255)")
            .HasColumnName("claim_type");

        builder.Property(a => a.ClaimValue)
            .IsRequired(false)
            .HasColumnType("varchar(255)")
            .HasColumnName("claim_value");
    }
}
