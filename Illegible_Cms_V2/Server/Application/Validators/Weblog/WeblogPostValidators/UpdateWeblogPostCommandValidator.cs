using FluentValidation;
using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCommands;
using Illegible_Cms_V2.Shared.BasicShared.Constants;

namespace Illegible_Cms_V2.Server.Application.Validators.Weblog.WeblogPostValidators
{
    public class UpdateWeblogPostCommandValidator : AbstractValidator<UpdateWeblogPostCommand>
    {
        public UpdateWeblogPostCommandValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0)
              .WithState(_ => WeblogPostErrors.InvalidPostIdValidationError);

            RuleFor(x => x.Title)
               .NotEmpty()
               .WithState(_ => WeblogPostErrors.InvalidPostTitleValidationError);

            // 50 <= summary caracters <= 100
            RuleFor(x => x.Summery)
                .MaximumLength(Defaults.LongLength)
                .MinimumLength(Defaults.MidLength)
                .WithState(_ => WeblogPostErrors.InvalidPostSummaryValidationError);

            // 200 <= text context caracters <= 2000
            RuleFor(x => x.TextContent)
                .MaximumLength(Defaults.BigLength2)
                .MinimumLength(Defaults.LongLength2)
                .WithState(_ => WeblogPostErrors.InvalidPostTextContextValidationError);
        }
    }
}
