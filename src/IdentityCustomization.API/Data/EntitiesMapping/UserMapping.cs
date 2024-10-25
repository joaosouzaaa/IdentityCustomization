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

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
           .IsRequired(true)
           .HasColumnType("varchar(50)")
           .HasColumnName("id");

        builder.Property(u => u.BirthDate)
            .IsRequired(true)
            .HasColumnType("datetime2")
            .HasColumnName("birth_date");

        builder.Property(u => u.UserName)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("user_name");

        builder.Property(u => u.NormalizedUserName)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("normalized_user_name");

        builder.Property(u => u.Email)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("email");

        builder.Property(u => u.NormalizedEmail)
            .IsRequired(true)
            .HasColumnType("varchar(256)")
            .HasColumnName("normalized_email");

        builder.Property(u => u.EmailConfirmed)
           .IsRequired(true)
           .HasColumnType("bit")
           .HasColumnName("email_confirmed");

        builder.Property(u => u.PasswordHash)
           .IsRequired(true)
           .HasColumnType("varchar(100)")
           .HasColumnName("password");

        builder.Property(u => u.SecurityStamp)
           .IsRequired(false)
           .HasColumnType("varchar(256)")
           .HasColumnName("security_stamp");

        builder.Property(u => u.ConcurrencyStamp)
           .IsRequired(false)
           .IsConcurrencyToken(true)
           .HasColumnType("varchar(256)")
           .HasColumnName("concurrency_stamp");

        builder.Property(u => u.PhoneNumber)
           .IsRequired(false)
           .HasColumnType("varchar(20)")
           .HasColumnName("phone_number");

        builder.Property(u => u.PhoneNumberConfirmed)
           .IsRequired(true)
           .HasColumnType("bit")
           .HasColumnName("phone_number_confirmed");

        builder.Property(u => u.TwoFactorEnabled)
           .IsRequired(true)
           .HasColumnType("bit")
           .HasColumnName("two_factor_enabled");

        builder.Property(u => u.LockoutEnd)
           .IsRequired(false)
           .HasColumnName("lockout_end");

        builder.Property(u => u.LockoutEnabled)
           .IsRequired(true)
           .HasColumnType("bit")
           .HasColumnName("lockout_enabled");

        builder.Property(u => u.AccessFailedCount)
           .IsRequired(true)
           .HasColumnType("int")
           .HasColumnName("access_failed_count");

        builder.HasMany(u => u.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired(true);

        builder.HasMany(u => u.UserClaims)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired(true);

        builder.HasMany(u => u.UserLogins)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired(true);

        builder.HasMany(u => u.UserTokens)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired(true);
    }
}
