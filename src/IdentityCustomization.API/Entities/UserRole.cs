using Microsoft.AspNetCore.Identity;

namespace IdentityCustomization.API.Entities;

public sealed class UserRole : IdentityUserRole<Guid>
{
    public User User { get; set; } = null!;
    public Role Role { get; set; } = null!;
}
