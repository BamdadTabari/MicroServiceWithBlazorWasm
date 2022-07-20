using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog;
using Illegible_Cms_V2.Server.Domain.Weblog;

namespace Illegible_Cms_V2.Server.Application.Interfaces.Repositories.Weblog
{
    public interface IWeblogPostRepository : IRepository<WeblogPost>
    {
        Task<WeblogPost> GetWeblogPostByIdAsync(int id);
        Task<WeblogPost> GetWeblogPostByWeblogPostNameAsync(string weblogPostname);
        Task<int> CountWeblogPostsByFilterAsync(WeblogPostFilter filter);
        Task<List<WeblogPost>> GetWeblogPostsByIdsAsync(IEnumerable<int> ids);
        Task<List<WeblogPost>> GetWeblogPostsByFilterAsync(WeblogPostFilter filter);
    }
}
