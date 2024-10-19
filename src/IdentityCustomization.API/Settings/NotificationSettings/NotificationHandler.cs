using IdentityCustomization.API.Interfaces.Settings;

namespace IdentityCustomization.API.Settings.NotificationSettings;

public sealed class NotificationHandler : INotificationHandler
{
    private readonly List<Notification> _notificationList;

    public NotificationHandler() =>
        _notificationList = [];

    public void AddNotification(string key, string message) =>
        _notificationList.Add(new(key, message));

    public List<Notification> GetNotifications() =>
        _notificationList;

    public bool HasNotifications() =>
        _notificationList.Any();
}
