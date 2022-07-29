using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Illegible_Cms_V2.Shared.Infrastructure.Errors;

namespace Illegible_Cms_V2.Identity.Application.Errors;

public static class RoleErrors
{
    public static ErrorModel RoleNotFoundError = new ErrorModel(
        code: 13001,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Role not found"
        ));

    public static ErrorModel DuplicateTitleError = new ErrorModel(
        code: 13002,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Title is registered before"
        ));
}