using FluentValidation;
using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCategoryCommands;

namespace Illegible_Cms_V2.Server.Application.Validators.Weblog.WeblogPostCategoryValidators
{
    public class DeleteWeblogPostCategoryCommandValidator : AbstractValidator<DeleteWeblogPostCategoryCommand>
    {
        public DeleteWeblogPostCategoryCommandValidator()
        {

            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0)
                .WithState(_ => WeblogPostCategoryErrors.InvalidPostCategoryIdValidationError);

        }
    }
}
