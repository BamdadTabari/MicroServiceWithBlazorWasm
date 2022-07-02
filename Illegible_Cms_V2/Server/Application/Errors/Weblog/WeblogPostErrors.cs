using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Illegible_Cms_V2.Shared.Infrastructure.Errors;

namespace Illegible_Cms_V2.Server.Application.Errors.Weblog
{
    public static class WeblogPostErrors
    {
        // Code ranges for WeblogPosts is between 20000 and 21000
        public static ErrorModel PostNotFoundError = new ErrorModel(
            code: 20001,
            title: "Weblog Post Error",
            (
                Language: Language.English,
                Message: "Post not found"
            ));

        public static ErrorModel DuplicatePostTitleError = new ErrorModel(
            code: 20002,
            title: "Weblog Post Error",
            (
                Language: Language.English,
                Message: "Post with this title already exists"
            ));

        public static ErrorModel InvalidPostIdValidationError = new ErrorModel(
            code: 20003,
            title: "Weblog Post Error",
            (
                Language: Language.English,
                Message: "Invalid post id"
            ));
    }
}
