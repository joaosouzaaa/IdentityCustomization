using IdentityCustomization.API.DataTransferObjects.Users;
using IdentityCustomization.API.Entities;
using IdentityCustomization.API.Interfaces.Mappers;

namespace IdentityCustomization.API.Mappers;

public sealed class UserMapper : IUserMapper
{
    public User CreateRequestToDomain(CreateUserRequest createRequest) =>
        new()
        {
            Email = createRequest.Email,
            UserName = createRequest.Email,
            PasswordHash = createRequest.Password,
            BirthDate = createRequest.BirthDate
        };

    public GetUserByIdResponse DomainToGetByIdResponse(User user) =>
        new(user.Id,
            user.UserName!,
            user.BirthDate);
}
