using IdentityCustomization.API.Constants;
using IdentityCustomization.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityCustomization.API.Data.EntitiesMapping;

internal sealed class UserLoginMapping : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable(TableNamesConstants.UserLoginTableName, SchemaNamesConstants.IdentitySchema);

        builder.HasKey(a =>
            new
            {
                a.LoginProvider,
                a.ProviderKey
            });

        builder.Property(a => a.LoginProvider)
            .IsRequired(true)
            .HasColumnType("varchar(128)")
            .HasColumnName("login_provider");

        builder.Property(a => a.ProviderKey)
            .IsRequired(true)
            .HasColumnType("varchar(128)")
            .HasColumnName("provider_key");

        builder.Property(a => a.ProviderDisplayName)
            .IsRequired(false)
            .HasColumnType("varchar(255)")
            .HasColumnName("provider_display_name");

        builder.Property(a => a.UserId)
            .IsRequired(true)
            .HasColumnName("user_id");
    }
}
