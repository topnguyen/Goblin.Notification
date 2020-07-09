using FluentValidation;
using Goblin.Notification.Share.Models;

namespace Goblin.Notification.Share.Validators
{
    public class GoblinNotificationNewEmailModelValidator : AbstractValidator<GoblinNotificationNewEmailModel>
    {
        public GoblinNotificationNewEmailModelValidator()
        {
            RuleFor(x => x.ToEmails).NotEmpty();
            RuleFor(x => x.Subject).NotEmpty();
            RuleFor(x => x.HtmlBody).NotEmpty();
        }
    }
}