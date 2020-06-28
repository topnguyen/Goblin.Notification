using Goblin.Notification.Contract.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Goblin.Notification.Repository.Maps
{
    public class FileGoblinEntityMap : GoblinEntityMap<SampleEntity>
    {
        public override void Map(EntityTypeBuilder<SampleEntity> builder)
        {
            base.Map(builder);

            builder.ToTable(nameof(SampleEntity));
        }
    }
}