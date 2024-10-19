using FluentValidation;
using IdentityCustomization.API.DataTransferObjects.Users;
using IdentityCustomization.API.Entities;
using IdentityCustomization.API.Interfaces.Mappers;
using IdentityCustomization.API.Interfaces.Repositories;
using IdentityCustomization.API.Interfaces.Services;
using IdentityCustomization.API.Interfaces.Settings;

namespace IdentityCustomization.API.Services;

public sealed class UserService(
    IUserRepository userRepository,
    IUserMapper userMapper,
    IValidator<User> userValidator,
    INotificationHandler notificationHandler)
    : IUserService
{
    public async Task CreateAsync(CreateUserRequest createUser, CancellationToken cancellationToken)
    {
        if (await userRepository.UserNameExistsAsync(createUser.Email, cancellationToken))
        {
            notificationHandler.AddNotification("Exists", "User Name already exists");

            return;
        }

        var user = userMapper.CreateRequestToDomain(createUser);

        if (!await IsValidAsync(user, cancellationToken))
        {
            return;
        }

        await userRepository.CreateAsync(user);
    }

    public async Task<GetUserByIdResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(id, cancellationToken);

        if (user is null)
        {
            return null;
        }

        return userMapper.DomainToGetByIdResponse(user);
    }

    private async Task<bool> IsValidAsync(User user, CancellationToken cancellationToken)
    {
        var validationResult = await userValidator.ValidateAsync(user, cancellationToken);

        if (validationResult.IsValid)
        {
            return true;
        }

        foreach (var error in validationResult.Errors)
        {
            notificationHandler.AddNotification(error.PropertyName, error.ErrorMessage);
        }

        return false;
    }
}
