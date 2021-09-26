using System.Threading.Tasks;
using AntDesign;

namespace Web.Shared.Components
{
    public class NotificationComponent
    {
        private readonly NotificationService _notification;

        public NotificationComponent(NotificationService notification)
        {
            _notification = notification;
        }

        public async Task Error(string message, int duration = 5)
        {
            await _notification.Open(new NotificationConfig()
            {
                Message = "ERROR",
                Description = message,
                NotificationType = NotificationType.Error,
                Duration = duration,
            });
        }
    }
}
