using FluentValidation;
using Goblin.Notification.Share.Models;

namespace Goblin.Notification.Core.Validators
{
    public class CreateSampleModelValidator : AbstractValidator<GoblinNotificationCreateSampleModel>
    {
        public CreateSampleModelValidator()
        {
            RuleFor(x => x.SampleData)
                .NotEmpty()
                .WithMessage("Please Input Sample Data");
        }
    }
}