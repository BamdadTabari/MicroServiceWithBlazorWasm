using Illegible_Cms_V2.Shared.BasicShared.Models;

namespace Illegible_Cms_V2.Identity.Api.Models.Requests.Users
{
    public class UpdateUserRequest
    {
        public PartialUpdatePayload Username { get; set; }
        public PartialUpdatePayload Mobile { get; set; }
        public PartialUpdatePayload Email { get; set; }
    }
}
