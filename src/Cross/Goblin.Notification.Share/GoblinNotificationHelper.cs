using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using Goblin.Core.Constants;
using Goblin.Core.Errors;
using Goblin.Core.Settings;
using Goblin.Notification.Share.Models;
using Goblin.Notification.Share.Validators;
using Microsoft.AspNetCore.Http;

namespace Goblin.Notification.Share
{
    public static class GoblinNotificationHelper
    {
        public static string Domain { get; set; } = string.Empty;

        public static string AuthorizationKey { get; set; } = string.Empty;

        public static readonly ISerializer JsonSerializer = new NewtonsoftJsonSerializer(GoblinJsonSetting.JsonSerializerSettings);

        private static IFlurlRequest GetRequest(long? loggedInUserId)
        {
            var request = Domain.WithHeader(GoblinHeaderKeys.Authorization, AuthorizationKey);

            if (loggedInUserId != null)
            {
                request = request.WithHeader(GoblinHeaderKeys.UserId, loggedInUserId);
            }

            request = request.ConfigureRequest(x =>
            {
                x.JsonSerializer = JsonSerializer;
            });

            return request;
        }

        public static async Task SendAsync(GoblinNotificationNewEmailModel model, CancellationToken cancellationToken = default)
        {
            var validator = new GoblinNotificationNewEmailModelValidator();

            var validatorResults = await validator.ValidateAsync(model, cancellationToken);

            if (!validatorResults.IsValid)
            {
                var errorModel = new GoblinErrorModel
                {
                    Code = StatusCodes.Status400BadRequest.ToString(),
                    Message = string.Join("; ", validatorResults.Errors.Select(x => x.ErrorMessage?.Trim('.'))),
                    AdditionalData = validatorResults.Errors.ToDictionary(x => x.PropertyName, x => (object) x.ErrorMessage)
                };

                throw new GoblinException(errorModel);
            }

            try
            {
                var endpoint = GetRequest(model.LoggedInUserId).AppendPathSegment(GoblinNotificationEndpoints.SendEmail);

                await endpoint
                    .PostJsonAsync(model, cancellationToken: cancellationToken)
                    .ConfigureAwait(true);
            }
            catch (FlurlHttpException ex)
            {
                await FlurlHttpExceptionHelper.HandleErrorAsync(ex).ConfigureAwait(true);
            }
        }
    }
}