using System.Threading;
using System.Threading.Tasks;
using Goblin.Notification.Share.Models;

namespace Goblin.Notification.Contract.Service
{
    public interface IEmailService
    {
        Task SendAsync(GoblinNotificationNewEmailModel model, CancellationToken cancellationToken = default);
    }
}