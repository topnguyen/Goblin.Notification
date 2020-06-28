using FluentValidation;
using Goblin.Notification.Share.Models;

namespace Goblin.Notification.Core.Validators
{
    public class CreateSampleModelValidator : AbstractValidator<GoblinNotificationNewEmailModel>
    {
        public CreateSampleModelValidator()
        {
            RuleFor(x => x.ToEmails).NotEmpty();
            RuleFor(x => x.Subject).NotEmpty();
            RuleFor(x => x.HtmlBody).NotEmpty();
        }
    }
}