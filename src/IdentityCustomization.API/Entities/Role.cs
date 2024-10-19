using Microsoft.AspNetCore.Identity;

namespace IdentityCustomization.API.Entities;

public sealed class Role : IdentityRole<Guid>
{
    public List<UserRole> UserRoles { get; set; } = [];
    public List<RoleClaim> RoleClaims { get; set; } = [];
}
