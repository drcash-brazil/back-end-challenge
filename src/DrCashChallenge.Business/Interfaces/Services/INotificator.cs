using DrCashChallenge.Business.Notifications;
using System.Collections.Generic;

namespace DrCashChallenge.Business.Interfaces.Services
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
