using IdentityCustomization.API.Entities;

namespace IdentityCustomization.API.Interfaces.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> UserNameExistsAsync(string userName, CancellationToken cancellationToken);
}
