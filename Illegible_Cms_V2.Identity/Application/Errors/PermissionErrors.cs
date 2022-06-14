using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Illegible_Cms_V2.Shared.Infrastructure.Errors;

namespace Illegible_Cms_V2.Identity.Application.Errors
{
    public static class PermissionErrors
    {
        public static ErrorModel InvalidPermissionIdValidationError = new ErrorModel(
            code: 14001,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Invalid permission id"
            ));

        public static ErrorModel InvalidClaimIdValidationError = new ErrorModel(
            code: 14001,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Invalid permission id"
            ));

        public static ErrorModel DuplicateClaimError = new ErrorModel(
            code: 14002,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Claim is registered before"
            ));

        public static ErrorModel ClaimNotFoundError = new ErrorModel(
            code: 14003,
            title: "Identity Error",
            (
                Language: Language.English,
                Message: "Claim not found"
            ));


    }
}

