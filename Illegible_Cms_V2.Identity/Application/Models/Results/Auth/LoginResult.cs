namespace Illegible_Cms_V2.Identity.Application.Models.Results.Auth;

public class LoginResult
{
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}