using FluentValidation;
using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCategoryCommands;
using Illegible_Cms_V2.Shared.BasicShared.Constants;

namespace Illegible_Cms_V2.Server.Application.Validators.Weblog.WeblogPostCategoryValidators
{
    public class CreateWeblogPostCategoryCammandValidator : AbstractValidator<CreateWeblogPostCategoryCommand>
    {
        public CreateWeblogPostCategoryCammandValidator()
        {
            // 50 <= Title length <= 100
            RuleFor(x => x.CategoryTitle)
                .NotEmpty()
                .MaximumLength(Defaults.ShortLength)
                .MinimumLength(Defaults.TinyLength)
                .WithState(_ => WeblogPostCategoryErrors.InvalidPostCategoryTitleValidationError);

            RuleFor(x => x.CategoryIcon)
                .NotEmpty()
                .WithState(_ => WeblogPostCategoryErrors.InvalidPostCategoryIconValidationError);
        }
    }
}
