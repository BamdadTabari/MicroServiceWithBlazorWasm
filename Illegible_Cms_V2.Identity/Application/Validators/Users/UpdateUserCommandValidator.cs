using FluentValidation;
using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;

namespace Illegible_Cms_V2.Identity.Application.Validators.Users;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithState(_ => CommonErrors.InvalidInputValidationError);
    }
}