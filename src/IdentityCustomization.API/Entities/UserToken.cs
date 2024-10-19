using Microsoft.AspNetCore.Identity;

namespace IdentityCustomization.API.Entities;

public sealed class UserToken : IdentityUserToken<Guid>
{
    public User User { get; set; } = null!;
}
