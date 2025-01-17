﻿using IdentityCustomization.API.Constants;
using IdentityCustomization.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityCustomization.API.Data.EntitiesMapping;

internal sealed class UserRoleMapping : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(TableNamesConstants.UserRoleTableName, SchemaNamesConstants.IdentitySchema);

        builder.HasKey(u =>
            new
            {
                u.UserId,
                u.RoleId
            });

        builder.Property(u => u.UserId)
            .IsRequired(true)
            .HasColumnName("user_id");

        builder.Property(u => u.RoleId)
            .IsRequired(true)
            .HasColumnName("role_id");
    }
}
