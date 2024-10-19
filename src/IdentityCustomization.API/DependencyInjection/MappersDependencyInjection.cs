using IdentityCustomization.API.Interfaces.Mappers;
using IdentityCustomization.API.Mappers;

namespace IdentityCustomization.API.DependencyInjection;

internal static class MappersDependencyInjection
{
    internal static void AddMappersDependencyInjection(this IServiceCollection services) =>
        services.AddScoped<IUserMapper, UserMapper>();
}
