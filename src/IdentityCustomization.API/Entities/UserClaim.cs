using Microsoft.AspNetCore.Identity;

namespace IdentityCustomization.API.Entities;

public sealed class UserClaim : IdentityUserClaim<Guid>
{
    public User User { get; set; } = null!;
}
