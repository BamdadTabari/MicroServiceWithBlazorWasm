using System.Security.Cryptography;

namespace Illegible_Cms_V2.Identity.Application.Helpers
{
    public sealed class PasswordHasher
    {
        private const int SaltSize = 128 / 8; // 128 bit
        private const int KeySize = 256 / 8; // 256 bit
        private const int Iteration = 10000;

        public static string Hash(string password)
        {
            using var algorithm =
                new Rfc2898DeriveBytes(password, SaltSize, Iteration, HashAlgorithmName.SHA512);
            var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
            var salt = Convert.ToBase64String(algorithm.Salt);

            return $"{key}.{salt}";
        }

        public static bool Check(string hash, string password)
        {
            var parts = hash.Split('.', 2);

            if (parts.Length != 2)
            {
                throw new FormatException("Unexpected hash format. " +
                                          "Should be formatted as `{iterations}.{salt}.{hash}`");
            }

            var key = Convert.FromBase64String(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);

            using var algorithm =
                new Rfc2898DeriveBytes(password, salt, Iteration, HashAlgorithmName.SHA512);
            var keyToCheck = algorithm.GetBytes(KeySize);
            return keyToCheck.SequenceEqual(key);
        }
    }
}
