using Elect.DI.Attributes;
using Goblin.Notification.Contract.Repository.Interfaces;
using Goblin.Notification.Contract.Service;
using System.Threading;
using System.Threading.Tasks;
using Elect.Mapper.AutoMapper.IQueryableUtils;
using Elect.Mapper.AutoMapper.ObjUtils;
using Goblin.Notification.Contract.Repository.Models;
using Goblin.Notification.Share.Models;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Notification.Service
{
    [ScopedDependency(ServiceType = typeof(ISampleService))]
    public class SampleService : Base.Service, ISampleService
    {
        private readonly IGoblinRepository<SampleEntity> _sampleRepo;

        public SampleService(IGoblinUnitOfWork goblinUnitOfWork, IGoblinRepository<SampleEntity> sampleRepo) : base(
            goblinUnitOfWork)
        {
            _sampleRepo = sampleRepo;
        }

        public async Task<GoblinNotificationSampleModel> CreateAsync(GoblinNotificationCreateSampleModel model,
            CancellationToken cancellationToken = default)
        {
            var sampleEntity = model.MapTo<SampleEntity>();

            _sampleRepo.Add(sampleEntity);

            await GoblinUnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            var fileModel = sampleEntity.MapTo<GoblinNotificationSampleModel>();

            return fileModel;
        }

        public async Task<GoblinNotificationSampleModel> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            var sampleModel =
                await _sampleRepo
                    .Get(x => x.Id == id)
                    .QueryTo<GoblinNotificationSampleModel>()
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken)
                    .ConfigureAwait(true);

            return sampleModel;
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var sampleEntity =
                await _sampleRepo
                    .Get(x => x.Id == id)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken)
                    .ConfigureAwait(true);
            
            _sampleRepo.Delete(sampleEntity);

            await GoblinUnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);
        }
    }
}