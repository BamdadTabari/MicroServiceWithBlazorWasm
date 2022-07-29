
using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Illegible_Cms_V2.Shared.Infrastructure.Errors;

namespace Illegible_Cms_V2.Identity.Application.Errors;

public static class CommonErrors
{
    // Code ranges for Identity is between 10001 and 19999

    public static ErrorModel InvalidInputValidationError = new ErrorModel(
        code: 10000,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid input"
        ));

    public static ErrorModel InvalidNameValidationError = new ErrorModel(
        code: 10001,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid name"
        ));

    public static ErrorModel InvalidLatinNameValidationError = new ErrorModel(
        code: 10002,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid name latin"
        ));

    public static ErrorModel InvalidTitleValidationError = new ErrorModel(
        code: 10003,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid title"
        ));

    public static ErrorModel InvalidPostalCodeValidationError = new ErrorModel(
        code: 10004,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid postal code"
        ));

    public static ErrorModel InvalidAddressValidationError = new ErrorModel(
        code: 10005,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid address"
        ));

}