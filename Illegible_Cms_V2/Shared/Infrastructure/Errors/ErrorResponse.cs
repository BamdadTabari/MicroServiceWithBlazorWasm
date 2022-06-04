using Illegible_Cms_V2.Shared.BasicShared.Constants;

namespace Illegible_Cms_V2.Shared.Infrastructure.Errors;

public class ErrorResponse
{
    private const string EnglishLanguage = "en";
    private const string DutchLanguage = "nl";
    private const string PersianLanguage = "fa";

    public ErrorResponse(ErrorModel error, string language = null)
    {
        Code = error.Code;
        Title = error.Title;
        Message = language switch
        {
            EnglishLanguage => error.Messages[Language.English],
            DutchLanguage => error.Messages[Language.Dutch],
            PersianLanguage => error.Messages[Language.Persian],
            _ => error.Messages[Language.English]
        };
    }

    public int Code { get; }
    public string Title { get; }
    public string Message { get; }
}