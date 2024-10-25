using IdentityCustomization.API.Constants;
using IdentityCustomization.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityCustomization.API.Data.EntitiesMapping;

internal sealed class UserTokenMapping : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable(TableNamesConstants.UserTokenTableName, SchemaNamesConstants.IdentitySchema);

        builder.HasKey(u =>
            new
            {
                u.UserId,
                u.LoginProvider,
                u.Name
            });

        builder.Property(u => u.LoginProvider)
            .IsRequired(true)
            .HasColumnType("varchar(255)")
            .HasColumnName("login_provider");

        builder.Property(u => u.Name)
            .IsRequired(true)
            .HasColumnType("varchar(255)")
            .HasColumnName("name");

        builder.Property(u => u.Value)
            .IsRequired(false)
            .HasColumnType("text")
            .HasColumnName("value");

        builder.Property(u => u.UserId)
            .IsRequired(true)
            .HasColumnName("user_id");
    }
}
