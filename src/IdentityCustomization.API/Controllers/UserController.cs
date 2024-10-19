using IdentityCustomization.API.DataTransferObjects.Users;
using IdentityCustomization.API.Interfaces.Services;
using IdentityCustomization.API.Settings.NotificationSettings;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCustomization.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task CreateAsync([FromBody] CreateUserRequest createUserRequest, CancellationToken cancellationToken) =>
        userService.CreateAsync(createUserRequest, cancellationToken);

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserByIdResponse))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<GetUserByIdResponse?> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken) =>
        userService.GetByIdAsync(id, cancellationToken);
}
