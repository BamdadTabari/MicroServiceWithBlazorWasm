namespace Illegible_Cms_V2.Identity.Api.Models.Requests.Users
{
    public class UpdateUserRolesRequest
    {
        public IEnumerable<string> RoleEids { get; set; }
    }
}
