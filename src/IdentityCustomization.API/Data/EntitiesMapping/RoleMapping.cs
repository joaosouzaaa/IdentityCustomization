using IdentityCustomization.API.Constants;
using IdentityCustomization.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityCustomization.API.Data.EntitiesMapping;

internal sealed class RoleMapping : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TableNamesConstants.RoleTableName, SchemaNamesConstants.IdentitySchema);

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .IsRequired(true)
            .HasColumnName("id");

        builder.Property(r => r.ConcurrencyStamp)
            .IsRequired(false)
            .IsConcurrencyToken(true)
            .HasColumnName("concurrency_stamp");

        builder.Property(r => r.Name)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("name");

        builder.Property(r => r.NormalizedName)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("normalized_name");

        builder.HasMany(r => r.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId)
            .IsRequired(true);

        builder.HasMany(r => r.RoleClaims)
            .WithOne(r => r.Role)
            .HasForeignKey(r => r.RoleId)
            .IsRequired(true);
    }
}
