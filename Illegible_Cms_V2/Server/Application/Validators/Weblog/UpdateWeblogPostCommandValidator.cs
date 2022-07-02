using FluentValidation;
using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog;

namespace Illegible_Cms_V2.Server.Application.Validators.Weblog
{
    public class UpdateWeblogPostCommandValidator : AbstractValidator<UpdateWeblogPostCommand>
    {
        public UpdateWeblogPostCommandValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0)
              .WithState(_ => WeblogPostErrors.InvalidPostIdValidationError);
        }
    }
}
