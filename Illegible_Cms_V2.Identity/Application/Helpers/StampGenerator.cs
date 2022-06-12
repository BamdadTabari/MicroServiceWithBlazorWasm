namespace Illegible_Cms_V2.Identity.Application.Helpers
{
    public sealed class StampGenerator
    {
        public static string CreateSecurityStamp(int length)
        {
            return RandomGenerator
                .GenerateString(length, AllowedCharacters.Alphanumeric)
                .ToUpper();
        }
    }
}
