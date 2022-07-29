using FluentValidation.Results;

namespace Illegible_Cms_V2.Server.Application.Helpers.Common;

public static class ValidationHelper
{
    public static string GetFirstErrorMessage(this ValidationResult result)
    {
        return result.Errors.FirstOrDefault()?.ErrorMessage ?? string.Empty;
    }

    public static object GetFirstErrorState(this ValidationResult result)
    {
        return result.Errors.FirstOrDefault()?.CustomState ?? string.Empty;
    }
}