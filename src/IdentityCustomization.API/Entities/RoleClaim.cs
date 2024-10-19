using Microsoft.AspNetCore.Identity;

namespace IdentityCustomization.API.Entities;

public sealed class RoleClaim : IdentityRoleClaim<Guid>
{
    public Role Role { get; set; } = null!;
}
