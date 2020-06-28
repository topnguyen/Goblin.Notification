namespace Goblin.Notification.Core
{
    public class SystemSetting
    {
        public static SystemSetting Current { get; set; }

        /// <summary>
        ///     Authorization Key to Access the Application
        /// </summary>
        /// <remarks>Use for protect Service in Public Network, empty or null for allow anonymous.</remarks>
        public string AuthorizationKey { get; set; }
        
        public string EmailSenderEmailAddress { get; set; }

        public string EmailSenderDisplayName { get; set; }
        
        // Smtp 
        
        public string EmailSmtpAccountUserName { get; set; }
        
        public string EmailSmtpAccountPassword { get; set; }

        /// <summary>
        ///     Default is "smtp.gmail.com"
        /// </summary>
        public string EmailSmtpHost { get; set; } = "smtp.gmail.com";

        /// <summary>
        ///     Default is "587"
        /// </summary>
        public int EmailSmtpPort { get; set; } = 587;

        /// <summary>
        ///     Default is "StartTlsWhenAvailable"
        /// </summary>
        public SecureSocketOption EmailSmtpSecureSocketOption { get; set; } = SecureSocketOption.StartTlsWhenAvailable;
    }
}