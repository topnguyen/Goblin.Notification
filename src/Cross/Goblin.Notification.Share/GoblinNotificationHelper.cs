using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Goblin.Core.Constants;
using Goblin.Core.Errors;
using Goblin.Notification.Share.Models;

namespace Goblin.Notification.Share
{
    public static class GoblinNotificationHelper
    {
        public static string Domain { get; set; } = string.Empty;

        public static async Task<GoblinNotificationSampleModel> CreateAsync(GoblinNotificationCreateSampleModel model,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = Domain;

                var fileModel = await endpoint
                    .AppendPathSegment(GoblinNotificationEndpoints.CreateSample)
                    .PostJsonAsync(model, cancellationToken: cancellationToken)
                    .ReceiveJson<GoblinNotificationSampleModel>()
                    .ConfigureAwait(true);

                return fileModel;
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

        public static async Task<GoblinNotificationSampleModel> GetAsync(GoblinNotificationGetFileModel model,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Domain.Replace("{id}", model.Id.ToString());

            var fileModel =
                await endpoint
                    .AppendPathSegment(GoblinNotificationEndpoints.GetSample)
                    .WithHeader(GoblinHeaderKeys.Authorization, model.AuthorizationKey)
                    .WithHeader(GoblinHeaderKeys.UserId, model.LoggedInUserId)
                    .SetQueryParam(GoblinHeaderKeys.Authorization, model.AuthorizationKey)
                    .SetQueryParam(GoblinHeaderKeys.UserId, model.LoggedInUserId)
                    .GetJsonAsync<GoblinNotificationSampleModel>(cancellationToken: cancellationToken)
                    .ConfigureAwait(true);

            return fileModel;
        }

        public static async Task DeleteAsync(GoblinNotificationDeleteSampleModel model,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Domain.Replace("{id}", model.Id.ToString());

            await endpoint
                .AppendPathSegment(GoblinNotificationEndpoints.DeleteSample)
                .WithHeader(GoblinHeaderKeys.Authorization, model.AuthorizationKey)
                .WithHeader(GoblinHeaderKeys.UserId, model.LoggedInUserId)
                .DeleteAsync(cancellationToken)
                .ConfigureAwait(true);
        }
    }
}