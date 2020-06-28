using AutoMapper;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;
using Goblin.Notification.Contract.Repository.Models;
using Goblin.Notification.Share.Models;

namespace Goblin.Notification.Mapper
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<GoblinNotificationCreateSampleModel, SampleEntity>()
                .IgnoreAllNonExisting();
            
            CreateMap<SampleEntity, GoblinNotificationSampleModel>()
                .IgnoreAllNonExisting();
        }
    }
}