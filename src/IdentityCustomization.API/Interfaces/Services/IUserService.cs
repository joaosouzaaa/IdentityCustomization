using IdentityCustomization.API.DataTransferObjects.Users;

namespace IdentityCustomization.API.Interfaces.Services;

public interface IUserService
{
    Task CreateAsync(CreateUserRequest createUser, CancellationToken cancellationToken);
    Task<GetUserByIdResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
