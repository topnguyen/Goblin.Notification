using Goblin.Notification.Contract.Repository.Models;

namespace Goblin.Notification.Contract.Repository.Interfaces
{
    public interface IGoblinUnitOfWork : Elect.Data.EF.Interfaces.UnitOfWork.IUnitOfWork
    {
        IGoblinRepository<T> GetRepository<T>() where T : GoblinEntity, new();
    }
}