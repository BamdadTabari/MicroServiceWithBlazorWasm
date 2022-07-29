using FluentValidation;
using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Auth;

namespace Illegible_Cms_V2.Identity.Application.Validators.Auth;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .When(x => string.IsNullOrEmpty(x.Email))
            .WithState(_ => UserErrors.InvalidEmailValidationError);

        RuleFor(x => x.UserName)
            .EmailAddress()
            .When(x => string.IsNullOrEmpty(x.UserName))
            .WithState(_ => UserErrors.InvalidUsernameValidationError);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithState(_ => UserErrors.InvalidPasswordValidationError);
    }
}