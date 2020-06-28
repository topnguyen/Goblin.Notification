using System.ComponentModel.DataAnnotations;
using Goblin.Core.Models;

namespace Goblin.Notification.Share.Models
{
    public class GoblinNotificationCreateSampleModel : GoblinApiRequestModel
    {
        [Required]
        public string SampleData { get; set; }
    }
}