using System.Threading;
using System.Threading.Tasks;
using Elect.Web.Swagger.Attributes;
using Goblin.Notification.Contract.Service;
using Goblin.Notification.Share;
using Goblin.Notification.Share.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Goblin.Notification.Controllers
{
    public class EmailController : BaseController
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        /// <summary>
        ///     Send Email
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ApiDocGroup("Email")]
        [HttpPost]
        [Route(GoblinNotificationEndpoints.SendEmail)]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Email Sent")]
        public async Task<IActionResult> Upload([FromBody] GoblinNotificationNewEmailModel model, CancellationToken cancellationToken = default)
        {
            await _emailService.SendAsync(model, cancellationToken);
            
            return NoContent();
        }
    }
}