using FluentValidation;
using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog;
using Illegible_Cms_V2.Shared.BasicShared.Constants;

namespace Illegible_Cms_V2.Server.Application.Validators.Weblog.WeblogPostCategoryValidators
{
    public class UpdateWeblogPostCategoryCommandValidator : AbstractValidator<UpdateWeblogPostCategoryCommand>
    {
        public UpdateWeblogPostCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .GreaterThan(0)
              .WithState(_ => WeblogPostCategoryErrors.InvalidPostCategoryIdValidationError);

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
