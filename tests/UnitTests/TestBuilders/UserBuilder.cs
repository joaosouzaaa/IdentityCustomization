using IdentityCustomization.API.DataTransferObjects.Users;
using IdentityCustomization.API.Entities;

namespace UnitTests.TestBuilders;

internal sealed class UserBuilder
{
    private readonly Guid _id = Guid.NewGuid();
    private string _userName = "test@email.com";
    private string _password = "te123st";
    private DateTime _birthDate = DateTime.UtcNow.AddDays(-1);

    public static UserBuilder NewObject() =>
        new();

    public User DomainBuild() =>
        new()
        {
            Id = _id,
            Email = _userName,
            UserName = _userName,
            BirthDate = _birthDate,
            PasswordHash = _password
        };

    public CreateUserRequest CreateRequestBuild() =>
        new(_userName,
            _password,
            _birthDate);

    public GetUserByIdResponse GetByIdResponseBuild() =>
        new(_id,
            _userName,
            _birthDate);

    public UserBuilder WithUserName(string userName)
    {
        _userName = userName;

        return this;
    }

    public UserBuilder WithPassword(string password)
    {
        _password = password;

        return this;
    }

    public UserBuilder WithBirthDate(DateTime birthDate)
    {
        _birthDate = birthDate;

        return this;
    }
}
