using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Illegible_Cms_V2.Shared.Infrastructure.Errors;

namespace Illegible_Cms_V2.Identity.Application.Errors
{
    public static class UserErrors
    {
        // Code ranges for UserManagement is between 10001 and 19999
        public static ErrorModel UserNotFoundError = new ErrorModel(
            code: 12001,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "User not found"
            ));

        public static ErrorModel DuplicateUsernameError = new ErrorModel(
            code: 12002,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Username is registered before"
            ));

        public static ErrorModel InvalidUserIdValidationError = new ErrorModel(
            code: 12003,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Invalid user id"
            ));

        public static ErrorModel InvalidUsernameValidationError = new ErrorModel(
            code: 12010,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Invalid username"
            ));

        public static ErrorModel InvalidEmailValidationError = new ErrorModel(
            code: 12011,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Invalid email address"
            ));

        public static ErrorModel InvalidMobileValidationError = new ErrorModel(
            code: 12013,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Invalid mobile"
            ));

        public static ErrorModel InvalidPasswordValidationError = new ErrorModel(
            code: 12014,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Password is not provided"
            ));

        public static ErrorModel InvalidFirstNameValidationError = new ErrorModel(
            code: 12015,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Invalid first name"
            ));

        public static ErrorModel InvalidLastNameValidationError = new ErrorModel(
            code: 12016,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Invalid last name"
            ));
        public static ErrorModel InvalidPhoneNumberValidationError = new ErrorModel(
            code: 12016,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Invalid phone number"
            ));
    }
}
