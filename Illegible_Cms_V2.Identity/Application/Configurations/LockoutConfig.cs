namespace Illegible_Cms_V2.Identity.Application.Configurations;

public class LockoutConfig
{
    public const string Key = "Lockout";

    public int FailedLoginLimit { get; set; }
    public TimeSpan Duration { get; set; }
}