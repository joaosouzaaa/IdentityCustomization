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

        builder.HasKey(a =>
            new
            {
                a.UserId,
                a.LoginProvider,
                a.Name
            });

        builder.Property(a => a.LoginProvider)
            .IsRequired(true)
            .HasColumnType("varchar(255)")
            .HasColumnName("login_provider");

        builder.Property(a => a.Name)
            .IsRequired(true)
            .HasColumnType("varchar(255)")
            .HasColumnName("name");

        builder.Property(a => a.Value)
            .IsRequired(false)
            .HasColumnType("text")
            .HasColumnName("value");

        builder.Property(a => a.UserId)
            .IsRequired(true)
            .HasColumnName("user_id");
    }
}
