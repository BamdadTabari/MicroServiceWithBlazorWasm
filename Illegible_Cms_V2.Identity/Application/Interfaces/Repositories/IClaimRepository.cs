using Illegible_Cms_V2.Identity.Application.Models.Filters.Claims;
using Illegible_Cms_V2.Identity.Domain.Claims;

namespace Illegible_Cms_V2.Identity.Application.Interfaces.Repositories
{
    public interface IClaimRepository : IRepository<Claim>
    {
        Task<Claim> GetClaimByIdAsync(int id);
        Task<List<Claim>> GetClaimsByIdsAsync(IEnumerable<int> ids);
        Task<List<Claim>> GetClaimsByFilterAsync(ClaimFilter filter);
        Task<int> CountClaimsByFilterAsync(ClaimFilter filter);
    }
}
