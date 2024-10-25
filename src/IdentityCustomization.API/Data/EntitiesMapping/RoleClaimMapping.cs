using IdentityCustomization.API.Constants;
using IdentityCustomization.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityCustomization.API.Data.EntitiesMapping;

internal sealed class RoleClaimMapping : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable(TableNamesConstants.RoleClaimTableName, SchemaNamesConstants.IdentitySchema);

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .IsRequired(true)
            .HasColumnName("id");

        builder.Property(r => r.RoleId)
            .IsRequired(true)
            .HasColumnName("role_id");

        builder.Property(r => r.ClaimType)
            .IsRequired(false)
            .HasColumnType("varchar(255)")
            .HasColumnName("claim_type");

        builder.Property(r => r.ClaimValue)
            .IsRequired(false)
            .HasColumnType("varchar(255)")
            .HasColumnName("claim_value");
    }
}
