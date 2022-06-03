using HashidsNet;

namespace Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;

public static class HashId
{
    private const string HashSalt =
        "amard-lJa2faL25HFJsfjag812fFkGh123aFR9tG67gDha3r4#vgwsrKfjHdHbKhg6J2KWe";

    private const int HashLength = 12;
    private const string HashAlphabets = "abcdefghklmnoprstuvw123456789";

    private static readonly Hashids Hasher = new(HashSalt, HashLength, HashAlphabets);

    public static string Encode(this int id)
    {
        return Hasher.Encode(id);
    }

    public static string Encode(this long id)
    {
        return Hasher.EncodeLong(id);
    }

    public static int Decode(this string eid)
    {
        try
        {
            return Hasher.Decode(eid)[0];
        }
        catch
        {
            return -1;
            throw new ArgumentException("Invalid encoded Id value");
        }
    }
}