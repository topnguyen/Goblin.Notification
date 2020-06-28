using System.Linq;
using Elect.DI.Attributes;
using Goblin.Notification.Contract.Repository.Interfaces;
using Goblin.Notification.Contract.Service;
using System.Threading;
using System.Threading.Tasks;
using Goblin.Notification.Core;
using Goblin.Notification.Share.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Goblin.Notification.Service
{
    [ScopedDependency(ServiceType = typeof(IEmailService))]
    public class EmailService : Base.Service, IEmailService
    {
        public EmailService(IGoblinUnitOfWork goblinUnitOfWork) : base(goblinUnitOfWork)
        {
        }

        public async Task SendAsync(GoblinNotificationNewEmailModel model, CancellationToken cancellationToken = default)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(SystemSetting.Current.EmailSenderDisplayName, SystemSetting.Current.EmailSenderEmailAddress));

            emailMessage.To.AddRange(model.ToEmails.Select(x => new MailboxAddress(x, x)));

            if (model.CcEmails?.Any() == true)
            {
                emailMessage.Cc.AddRange(model.CcEmails.Select(x => new MailboxAddress(x, x)));
            }

            if (model.BccEmails?.Any() == true)
            {
                emailMessage.Bcc.AddRange(model.BccEmails.Select(x => new MailboxAddress(x, x)));
            }
            
            emailMessage.Subject = model.Subject;

            emailMessage.Body = new TextPart("html")
            {
                Text = model.HtmlBody
            };

            using var client = new SmtpClient();
            
            // Convert System SecureSocketOption to Mail kit SecureSocketOptions
            var secureSocketOptions = (SecureSocketOptions) ((int) SystemSetting.Current.EmailSmtpSecureSocketOption);

            await client.ConnectAsync(SystemSetting.Current.EmailSmtpHost, SystemSetting.Current.EmailSmtpPort, secureSocketOptions, cancellationToken).ConfigureAwait(true);

            await client.AuthenticateAsync(SystemSetting.Current.EmailSmtpAccountUserName, SystemSetting.Current.EmailSmtpAccountPassword, cancellationToken).ConfigureAwait(true);

            await client.SendAsync(emailMessage, cancellationToken).ConfigureAwait(true);
        }
    }
}