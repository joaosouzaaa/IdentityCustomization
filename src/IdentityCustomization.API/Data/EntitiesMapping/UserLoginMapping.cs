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

        builder.HasKey(u =>
            new
            {
                u.LoginProvider,
                u.ProviderKey
            });

        builder.Property(u => u.LoginProvider)
            .IsRequired(true)
            .HasColumnType("varchar(128)")
            .HasColumnName("login_provider");

        builder.Property(u => u.ProviderKey)
            .IsRequired(true)
            .HasColumnType("varchar(128)")
            .HasColumnName("provider_key");

        builder.Property(u => u.ProviderDisplayName)
            .IsRequired(false)
            .HasColumnType("varchar(255)")
            .HasColumnName("provider_display_name");

        builder.Property(u => u.UserId)
            .IsRequired(true)
            .HasColumnName("user_id");
    }
}
