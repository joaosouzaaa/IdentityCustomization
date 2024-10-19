using IdentityCustomization.API.DataTransferObjects.Users;
using IdentityCustomization.API.Entities;

namespace IdentityCustomization.API.Interfaces.Mappers;

public interface IUserMapper
{
    User CreateRequestToDomain(CreateUserRequest createRequest);
    GetUserByIdResponse DomainToGetByIdResponse(User user);
}
