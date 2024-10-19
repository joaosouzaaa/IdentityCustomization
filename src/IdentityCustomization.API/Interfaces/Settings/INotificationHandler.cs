using IdentityCustomization.API.Settings.NotificationSettings;

namespace IdentityCustomization.API.Interfaces.Settings;

public interface INotificationHandler
{
    void AddNotification(string key, string message);
    List<Notification> GetNotifications();
    bool HasNotifications();
}
