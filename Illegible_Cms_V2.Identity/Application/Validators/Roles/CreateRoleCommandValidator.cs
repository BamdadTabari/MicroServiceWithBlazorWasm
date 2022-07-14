using FluentValidation;
using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;
using Illegible_Cms_V2.Shared.BasicShared.Constants;

namespace Illegible_Cms_V2.Identity.Application.Validators.Roles
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.PermissionIds)
                .NotEmpty()
                .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

            RuleFor(x => x.Title)
                .MaximumLength(Defaults.NameLength)
                .WithState(_ => CommonErrors.InvalidTitleValidationError);

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithState(_ => CommonErrors.InvalidTitleValidationError);

        }
    }
}
