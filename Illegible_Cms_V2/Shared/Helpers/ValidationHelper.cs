using FluentValidation.Results;

namespace Illegible_Cms_V2.Shared.Helpers
{
    public static class ValidationHelper
    {
        public static string? GetFirstErrorMessage(this ValidationResult result)
        {
            return result.Errors.FirstOrDefault()?.ErrorMessage;
        }

        public static object? GetFirstErrorState(this ValidationResult result)
        {
            return result.Errors.FirstOrDefault()?.CustomState;
        }
    }
}
