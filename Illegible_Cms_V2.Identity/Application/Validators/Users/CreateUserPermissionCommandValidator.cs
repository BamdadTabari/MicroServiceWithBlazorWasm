using FluentValidation;
using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;

namespace Illegible_Cms_V2.Identity.Application.Validators.Users;

public class CreateUserPermissionCommandValidator : AbstractValidator<CreateUserPermissionCommand>
{
    public CreateUserPermissionCommandValidator()
    {

        RuleFor(x => x.PermissionId)
            .NotEmpty()
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.PermissionId)
            .GreaterThan(0)
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidUserIdValidationError);

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => UserErrors.InvalidUserIdValidationError);

    }
}