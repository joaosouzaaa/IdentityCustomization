using IdentityCustomization.API.Data.DatabaseContexts;
using IdentityCustomization.API.Entities;
using Microsoft.AspNetCore.Identity;

namespace IdentityCustomization.API.DependencyInjection;

internal static class IdentityDependencyInjection
{
    internal static void AddIdentityDependencyInjection(this IServiceCollection services) =>
        services.AddIdentityCore<User>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 5;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddUserManager<UserManager<User>>()
        .AddDefaultTokenProviders();
}
