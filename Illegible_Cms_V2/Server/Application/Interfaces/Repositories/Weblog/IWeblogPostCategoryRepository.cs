using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog;
using Illegible_Cms_V2.Server.Domain.Weblog;

namespace Illegible_Cms_V2.Server.Application.Interfaces.Repositories.Weblog
{
    public interface IWeblogPostCategoryRepository : IRepository<WeblogPostCategory>
    {
        Task<WeblogPostCategory> GetWeblogPostCategoryByIdAsync(int id);
        Task<WeblogPostCategory> GetWeblogPostCategoryByWeblogPostCategoryTitleAsync(string weblogPostCategoryTitle);
        Task<int> CountWeblogPostCategoriesByFilterAsync(WeblogPostCategoryFilter filter);
        Task<List<WeblogPostCategory>> GetWeblogPostCategoriesByIdsAsync(IEnumerable<int> ids);
        Task<List<WeblogPostCategory>> GetWeblogPostCategoriesByFilterAsync(WeblogPostCategoryFilter filter);
    }
}
