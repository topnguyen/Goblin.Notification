using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Goblin.Core.Models;

namespace Goblin.Notification.Share.Models
{
    public class GoblinNotificationNewEmailModel: GoblinApiRequestModel
    {
        [Required]
        public List<string> ToEmails { get; set; }
        
        public List<string> CcEmails { get; set; }
        
        public List<string> BccEmails { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string HtmlBody { get; set; }
    }
}