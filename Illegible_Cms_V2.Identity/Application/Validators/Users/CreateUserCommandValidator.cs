using FluentValidation;
using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Shared.BasicShared.Constants;

namespace Illegible_Cms_V2.Identity.Application.Validators.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithState(_ => UserErrors.InvalidUsernameValidationError);

            RuleFor(x => x.Username)
                .Length(2, Defaults.UsernameLength)
                .WithState(_ => UserErrors.InvalidUsernameValidationError);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(Defaults.MinPasswordLength)
                .WithState(_ => UserErrors.InvalidPasswordValidationError);

            RuleFor(x => x.Mobile)
                .MaximumLength(Defaults.MobileNumberLength)
                .WithState(_ => UserErrors.InvalidPhoneNumberValidationError);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithState(_ => UserErrors.InvalidEmailValidationError);
        }
    }
}

