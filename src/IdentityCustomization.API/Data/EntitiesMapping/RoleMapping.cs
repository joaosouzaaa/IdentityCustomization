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

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .IsRequired(true)
            .HasColumnName("id");

        builder.Property(a => a.ConcurrencyStamp)
            .IsRequired(false)
            .IsConcurrencyToken(true)
            .HasColumnName("concurrency_stamp");

        builder.Property(a => a.Name)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("name");

        builder.Property(a => a.NormalizedName)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("normalized_name");

        builder.HasMany(a => a.UserRoles)
            .WithOne(a => a.Role)
            .HasForeignKey(a => a.RoleId)
            .IsRequired(true);

        builder.HasMany(a => a.RoleClaims)
            .WithOne(a => a.Role)
            .HasForeignKey(a => a.RoleId)
            .IsRequired(true);
    }
}
