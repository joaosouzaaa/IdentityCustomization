using IdentityCustomization.API.Mappers;
using UnitTests.TestBuilders;

namespace UnitTests.MappersTests;

public sealed class UserMapperTests
{
    private readonly UserMapper _userMapper;

    public UserMapperTests()
    {
        _userMapper = new UserMapper();
    }

    [Fact]
    public void CreateRequestToDomain_SuccessfulScenario_ReturnsDomainEntity()
    {
        // A
        var createUserRequest = UserBuilder.NewObject().CreateRequestBuild();

        // A
        var userResult = _userMapper.CreateRequestToDomain(createUserRequest);

        // A
        Assert.Equal(createUserRequest.Email, userResult.Email);
        Assert.Equal(createUserRequest.Email, userResult.UserName);
        Assert.Equal(createUserRequest.Password, userResult.PasswordHash);
    }

    [Fact]
    public void DomainToGetByIdResponse_SuccessfulScenario_ReturnsGetByIdResponse()
    {
        // A
        var user = UserBuilder.NewObject().DomainBuild();

        // A
        var getByIdResponseResult = _userMapper.DomainToGetByIdResponse(user);

        // A
        Assert.Equal(user.Id, getByIdResponseResult.Id);
        Assert.Equal(user.UserName, getByIdResponseResult.Email);
        Assert.Equal(user.BirthDate, getByIdResponseResult.BirthDate);
    }
}
