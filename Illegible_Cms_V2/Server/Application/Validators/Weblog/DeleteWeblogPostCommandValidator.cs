using FluentValidation;
using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog;

namespace Illegible_Cms_V2.Server.Application.Validators.Weblog
{
    public class DeleteWeblogPostCommandValidator : AbstractValidator<DeleteWeblogPostCommand>
    {
        public DeleteWeblogPostCommandValidator()
        {
            
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithState(_ => WeblogPostErrors.InvalidPostIdValidationError);

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithState(_ => WeblogPostErrors.InvalidPostIdValidationError);
        }
    }
}
