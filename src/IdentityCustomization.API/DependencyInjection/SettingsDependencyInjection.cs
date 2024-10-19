using FluentValidation;
using IdentityCustomization.API.Filters;
using IdentityCustomization.API.Interfaces.Settings;
using IdentityCustomization.API.Settings.NotificationSettings;
using System.Reflection;

namespace IdentityCustomization.API.DependencyInjection;

internal static class SettingsDependencyInjection
{
    internal static void AddSettingsDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
        services.AddScoped<NotificationFilter>();

        services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));
    }
}
