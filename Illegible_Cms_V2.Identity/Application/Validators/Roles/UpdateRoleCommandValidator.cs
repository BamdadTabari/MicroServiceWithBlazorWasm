using FluentValidation;
using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;
using Illegible_Cms_V2.Shared.BasicShared.Constants;

namespace Illegible_Cms_V2.Identity.Application.Validators.Roles
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            // Role id
            RuleFor(x => x.RoleId)
                .GreaterThan(0)
                .WithState(_ => CommonErrors.InvalidInputValidationError);

            // Permission id
            RuleFor(x => x.PermissionIds)
                .NotEmpty()
                .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

            // Name
            RuleFor(x => x.Name)
                .MaximumLength(Defaults.NameLength)
                .WithState(_ => CommonErrors.InvalidNameValidationError);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithState(_ => CommonErrors.InvalidNameValidationError);

            // Title
            RuleFor(x => x.Title)
                .MaximumLength(Defaults.NameLength)
                .WithState(_ => CommonErrors.InvalidTitleValidationError);

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithState(_ => CommonErrors.InvalidTitleValidationError);

        }
    }
}
