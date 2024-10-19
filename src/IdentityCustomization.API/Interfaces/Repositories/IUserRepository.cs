using IdentityCustomization.API.Entities;

namespace IdentityCustomization.API.Interfaces.Repositories;

public interface IUserRepository
{
    Task CreateAsync(User user);
}
