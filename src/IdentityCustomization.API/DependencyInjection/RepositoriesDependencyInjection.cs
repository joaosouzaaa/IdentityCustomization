using IdentityCustomization.API.Data.Repositories;
using IdentityCustomization.API.Interfaces.Repositories;

namespace IdentityCustomization.API.DependencyInjection;

internal static class RepositoriesDependencyInjection
{
    internal static void AddRepositoriesDependencyInjection(this IServiceCollection services) =>
        services.AddScoped<IUserRepository, UserRepository>();
}
