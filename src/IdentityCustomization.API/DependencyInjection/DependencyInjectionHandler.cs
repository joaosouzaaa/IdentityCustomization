using IdentityCustomization.API.Data.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace IdentityCustomization.API.DependencyInjection;

internal static class DependencyInjectionHandler
{
    internal static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        services.AddAuthentication();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentityDependencyInjection();
        services.AddRepositoriesDependencyInjection();
    }
}
