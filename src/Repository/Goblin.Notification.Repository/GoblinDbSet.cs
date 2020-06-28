using Goblin.Notification.Contract.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Notification.Repository
{
    public sealed partial class GoblinDbContext
    {
        public DbSet<SampleEntity> Samples { get; set; }
    }
}