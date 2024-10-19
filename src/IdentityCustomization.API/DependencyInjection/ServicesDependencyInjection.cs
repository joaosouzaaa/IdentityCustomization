using IdentityCustomization.API.Interfaces.Services;
using IdentityCustomization.API.Services;

namespace IdentityCustomization.API.DependencyInjection;

internal static class ServicesDependencyInjection
{
    internal static void AddServicesDependencyInjection(this IServiceCollection services) =>
        services.AddScoped<IUserService, UserService>();
}
