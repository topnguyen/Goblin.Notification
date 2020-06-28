namespace Goblin.Notification.Share
{
    public static class GoblinNotificationEndpoints
    {
        /// <summary>
        ///     HTTP Method: PUT
        /// </summary>
        public const string CreateSample = "/samples";
        
        /// <summary>
        ///     HTTP Method: GET
        /// </summary>
        public const string GetSample = "/samples/{id}";
        
        /// <summary>
        ///     HTTP Method: DELETE
        /// </summary>
        public const string DeleteSample = "/samples/{id}";
    }
}