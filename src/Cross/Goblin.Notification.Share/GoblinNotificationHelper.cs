using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Goblin.Core.Errors;
using Goblin.Notification.Share.Models;

namespace Goblin.Notification.Share
{
    public static class GoblinNotificationHelper
    {
        public static string Domain { get; set; } = string.Empty;

        public static async Task SendAsync(GoblinNotificationNewEmailModel model, CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = Domain;

                 await endpoint
                    .AppendPathSegment(GoblinNotificationEndpoints.SendEmail)
                    .PostJsonAsync(model, cancellationToken: cancellationToken)
                    .ConfigureAwait(true);
            }
            catch (FlurlHttpException ex)
            {
                var goblinErrorModel = await ex.GetResponseJsonAsync<GoblinErrorModel>().ConfigureAwait(true);

                if (goblinErrorModel != null)
                {
                    throw new GoblinException(goblinErrorModel);
                }

                var responseString = await ex.GetResponseStringAsync().ConfigureAwait(true);

                var message = responseString ?? ex.Message;

                throw new Exception(message);
            }
        }
    }
}