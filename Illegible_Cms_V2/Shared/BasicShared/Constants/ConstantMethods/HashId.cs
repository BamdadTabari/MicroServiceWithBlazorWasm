using HashidsNet;

namespace Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;

public static class HashId
{
    private const string HashSalt =
        "illegible-0o0o1faL25UUUsfjag812fFkGh123aFR9tG67gDha3r4#vgwsrKfjHdHbKhgpls601";

    private const int MinHashLength = 12;
    private const string HashAlphabets = "abcdefghklmnoprstuvw123456789";

    private static readonly Hashids Hasher = new(HashSalt, MinHashLength, HashAlphabets);

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
        }
    }
}