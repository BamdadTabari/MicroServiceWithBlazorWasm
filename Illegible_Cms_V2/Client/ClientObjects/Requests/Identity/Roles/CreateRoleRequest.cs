namespace Illegible_Cms_V2.Client.ClientObjects.Requests.Identity.Roles;

public class CreateRoleRequest
{
    public string Title { get; set; }
    public IList<string> PermissionEids { get; set; }
}