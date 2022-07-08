using Illegible_Cms_V2.Server.Application.Models.Base.Weblog;
using Illegible_Cms_V2.Server.Domain.Weblog;

namespace Illegible_Cms_V2.Server.Application.Mappers.Weblog
{
    public static class WeblogPostMapper
    {
        public static WeblogPostModel MapToWeblogPostModel(this WeblogPost weblogPost)
        {
            return new WeblogPostModel()
            {
                Id = weblogPost.Id,
                Title = weblogPost.Title,
                TextContent = weblogPost.TextContent,
                Summery = weblogPost.Summery
            };
        }

        public static IEnumerable<WeblogPostModel> MapToWeblogPostModels(this IEnumerable<WeblogPost> weblogPosts)
        {
            foreach (var weblogPost in weblogPosts)
                yield return weblogPost.MapToWeblogPostModel();
        }
    }
}
