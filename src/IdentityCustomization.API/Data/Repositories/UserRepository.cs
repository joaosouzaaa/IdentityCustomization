using IdentityCustomization.API.Data.DatabaseContexts;
using IdentityCustomization.API.Entities;
using IdentityCustomization.API.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityCustomization.API.Data.Repositories;

public sealed class UserRepository(
    UserManager<User> userManager,
    ApplicationDbContext dbContext)
    : IUserRepository,
    IDisposable
{
    public Task CreateAsync(User user) =>
        userManager.CreateAsync(user, user.PasswordHash!);

    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

    public Task<bool> UserNameExistsAsync(string userName, CancellationToken cancellationToken) =>
        dbContext.Users.AnyAsync(u => u.UserName == userName, cancellationToken);

    public void Dispose()
    {
        userManager.Dispose();
        dbContext.Dispose();

        GC.SuppressFinalize(this);
    }
}
