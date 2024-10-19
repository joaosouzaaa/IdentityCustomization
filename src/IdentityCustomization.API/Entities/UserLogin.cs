using Microsoft.AspNetCore.Identity;

namespace IdentityCustomization.API.Entities;

public sealed class UserLogin : IdentityUserLogin<Guid>
{
    public User User { get; set; } = null!;
}
