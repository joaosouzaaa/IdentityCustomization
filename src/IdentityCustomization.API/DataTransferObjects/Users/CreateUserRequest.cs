namespace IdentityCustomization.API.DataTransferObjects.Users;

public sealed record CreateUserRequest(
    string Email,
    string Password,
    DateTime BirthDate);
