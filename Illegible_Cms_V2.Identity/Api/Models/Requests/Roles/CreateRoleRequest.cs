namespace Illegible_Cms_V2.Identity.Api.Models.Requests.Roles
{
    public class CreateRoleRequest
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public IList<string> PermissionEids { get; set; }
    }
}
