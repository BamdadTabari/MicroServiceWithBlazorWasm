using FluentValidation;
using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;

namespace Illegible_Cms_V2.Identity.Application.Validators.Users
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            // Permission Id
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);

            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithState(_ => PermissionErrors.InvalidClaimIdValidationError);
        }
    }
}
