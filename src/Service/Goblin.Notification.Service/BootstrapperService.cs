using Elect.DI.Attributes;
using Goblin.Notification.Contract.Repository.Interfaces;
using Goblin.Notification.Contract.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Goblin.Notification.Service
{
    [ScopedDependency(ServiceType = typeof(IBootstrapperService))]
    public class BootstrapperService : Base.Service, IBootstrapperService
    {
        public BootstrapperService(IGoblinUnitOfWork goblinUnitOfWork) : base(goblinUnitOfWork)
        {
        }

        public Task InitialAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task RebuildAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}