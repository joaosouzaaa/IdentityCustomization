using IdentityCustomization.API.Data.DatabaseContexts;
using IdentityCustomization.API.Entities;
using IdentityCustomization.API.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IdentityCustomization.API.Data.Repositories;

public sealed class UserRepository(
    UserManager<User> userManager,
    ApplicationDbContext dbContext)
    : IUserRepository,
    IDisposable
{
    public Task CreateAsync(User user) =>
        userManager.CreateAsync(user, user.PasswordHash!);

    public void Dispose()
    {
        userManager.Dispose();
        dbContext.Dispose();

        GC.SuppressFinalize(this);
    }
}
