using FluentValidation;
using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;

namespace Illegible_Cms_V2.Identity.Application.Validators.Roles
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator()
        {
            RuleFor(x => x.RoleId)
                .GreaterThan(0)
                .WithState(_ => CommonErrors.InvalidInputValidationError);
        }
    }
}
