using System.Threading;
using System.Threading.Tasks;
using Goblin.Notification.Share.Models;

namespace Goblin.Notification.Contract.Service
{
    public interface ISampleService
    {
        Task<GoblinNotificationSampleModel> CreateAsync(GoblinNotificationCreateSampleModel model, CancellationToken cancellationToken = default);
        
        Task<GoblinNotificationSampleModel> GetAsync(long id, CancellationToken cancellationToken = default);
        
        Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}