using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Illegible_Cms_V2.Shared.Infrastructure.Errors;

namespace Illegible_Cms_V2.Identity.Application.Errors;

public static class AuthErrors
{
    public static ErrorModel InvalidLoginError = new ErrorModel(
        code: 11001,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid login information"
        ));

    public static ErrorModel InvalidCredentialsError = new ErrorModel(
        code: 11002,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid credentials"
        ));

    public static ErrorModel UnauthorizedRequestError = new ErrorModel(
        code: 11003,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Unauthorized request"
        ));
}