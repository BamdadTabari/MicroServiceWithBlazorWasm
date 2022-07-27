using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Illegible_Cms_V2.Shared.Infrastructure.Errors;

namespace Illegible_Cms_V2.Server.Application.Errors.Weblog
{
    public static class WeblogPostCategoryErrors
    {
        // Code ranges for WeblogPosts is between 21000 and 22000
        public static ErrorModel PostCategoryNotFoundError = new ErrorModel(
            code: 21001,
            title: "Weblog Post Category Error",
            (
                Language: Language.English,
                Message: "Post category not found"
            ));

        public static ErrorModel DuplicatePostCategoryTitleError = new ErrorModel(
            code: 21002,
            title: "Weblog Post category Error",
            (
                Language: Language.English,
                Message: "Post Category with this title already exists"
            ));

        public static ErrorModel InvalidPostCategoryIdValidationError = new ErrorModel(
            code: 21003,
            title: "Weblog Post Category Error",
            (
                Language: Language.English,
                Message: "Invalid post category id"
            ));
        public static ErrorModel InvalidPostCategoryTitleValidationError = new ErrorModel(
           code: 21004,
           title: "Weblog Post Category Error",
           (
               Language: Language.English,
               Message: "Invalid post Category title"
           ));
        public static ErrorModel InvalidPostCategoryIconValidationError = new ErrorModel(
          code: 21004,
          title: "Weblog Post Category Error",
          (
              Language: Language.English,
              Message: "Invalid post Category icon"
          ));
    }
}
