using FluentValidation;
using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;

namespace Illegible_Cms_V2.Identity.Application.Validators.Users
{
    public class DeleteUserPermissionCommandValidator : AbstractValidator<DeleteUserPermissionCommand>
    {
        public DeleteUserPermissionCommandValidator()
        {
            // Permission Id
            RuleFor(x => x.ClaimId)
                .NotEmpty()
                .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);

            RuleFor(x => x.ClaimId)
                .GreaterThan(0)
                .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);

        }
    }
}
