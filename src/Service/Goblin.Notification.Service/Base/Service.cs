using Goblin.Notification.Contract.Repository.Interfaces;

namespace Goblin.Notification.Service.Base
{
    public abstract class Service
    {
        protected readonly IGoblinUnitOfWork GoblinUnitOfWork;

        protected Service(IGoblinUnitOfWork goblinUnitOfWork)
        {
            GoblinUnitOfWork = goblinUnitOfWork;
        }
    }
}