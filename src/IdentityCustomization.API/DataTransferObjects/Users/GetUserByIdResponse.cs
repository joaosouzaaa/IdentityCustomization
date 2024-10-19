namespace IdentityCustomization.API.DataTransferObjects.Users;

public sealed record GetUserByIdResponse(
    Guid Id,
    string Email,
    DateTime BirthDate);
