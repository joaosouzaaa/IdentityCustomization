using Microsoft.AspNetCore.Identity;

namespace IdentityCustomization.API.Entities;

public sealed class User : IdentityUser<Guid>
{
    public required DateTime BirthDate { get; set; }
    public List<UserRole> UserRoles { get; set; } = [];
    public List<UserClaim> UserClaims { get; set; } = [];
    public List<UserLogin> UserLogins { get; set; } = [];
    public List<UserToken> UserTokens { get; set; } = [];
}
