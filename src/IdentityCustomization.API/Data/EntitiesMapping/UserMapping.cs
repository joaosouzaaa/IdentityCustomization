using IdentityCustomization.API.Constants;
using IdentityCustomization.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityCustomization.API.Data.EntitiesMapping;

internal sealed class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNamesConstants.UserTableName, SchemaNamesConstants.IdentitySchema);

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
           .IsRequired(true)
           .HasColumnType("varchar(50)")
           .HasColumnName("id");

        builder.Property(u => u.BirthDate)
            .IsRequired(true)
            .HasColumnType("datetime2")
            .HasColumnName("birth_date");

        builder.Property(a => a.UserName)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("user_name");

        builder.Property(a => a.NormalizedUserName)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("normalized_user_name");

        builder.Property(a => a.Email)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("email");

        builder.Property(a => a.NormalizedEmail)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("normalized_email");

        builder.Property(a => a.EmailConfirmed)
           .IsRequired(true)
           .HasColumnType("bit")
           .HasColumnName("email_confirmed");

        builder.Property(a => a.PasswordHash)
           .IsRequired(true)
           .HasColumnType("varchar(100)")
           .HasColumnName("password");

        builder.Property(a => a.SecurityStamp)
           .IsRequired(false)
           .HasColumnType("varchar(256)")
           .HasColumnName("security_stamp");

        builder.Property(a => a.ConcurrencyStamp)
           .IsRequired(false)
           .IsConcurrencyToken(true)
           .HasColumnType("varchar(256)")
           .HasColumnName("concurrency_stamp");

        builder.Property(a => a.PhoneNumber)
           .IsRequired(false)
           .HasColumnType("varchar(20)")
           .HasColumnName("phone_number");

        builder.Property(a => a.PhoneNumberConfirmed)
           .IsRequired(true)
           .HasColumnType("bit")
           .HasColumnName("phone_number_confirmed");

        builder.Property(a => a.TwoFactorEnabled)
           .IsRequired(true)
           .HasColumnType("bit")
           .HasColumnName("two_factor_enabled");

        builder.Property(a => a.LockoutEnd)
           .IsRequired(false)
           .HasColumnName("lockout_end");

        builder.Property(a => a.LockoutEnabled)
           .IsRequired(true)
           .HasColumnType("bit")
           .HasColumnName("lockout_enabled");

        builder.Property(a => a.AccessFailedCount)
           .IsRequired(true)
           .HasColumnType("int")
           .HasColumnName("access_failed_count");

        builder.HasMany(a => a.UserRoles)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .IsRequired(true);

        builder.HasMany(a => a.UserClaims)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .IsRequired(true);

        builder.HasMany(a => a.UserLogins)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .IsRequired(true);

        builder.HasMany(a => a.UserTokens)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .IsRequired(true);
    }
}
