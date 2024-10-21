using System.Security.Cryptography;

namespace GripOnMash.Shared.Utilities
{
    public static class PasswordGenerator
    {
        public static string Generate(
        int requiredLength = 8,
        int requiredUniqueChars = 4,
        bool requireDigit = true,
        bool requireLowercase = true,
        bool requireNonAlphanumeric = true,
        bool requireUppercase = true)
        {
            string[] randomChars =
            [
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                "abcdefghijkmnopqrstuvwxyz",    // lowercase
                "0123456789",                   // digits
                "!@$?_-"                        // non-alphanumeric
            ];
            var chars = new List<char>();

            if (requireUppercase)
                chars.Insert(0,
                    randomChars[0][RandomNumberGenerator.GetInt32(0, randomChars[0].Length)]);

            if (requireLowercase)
                chars.Insert(RandomNumberGenerator.GetInt32(0, chars.Count),
                    randomChars[1][RandomNumberGenerator.GetInt32(0, randomChars[1].Length)]);

            if (requireDigit)
                chars.Insert(RandomNumberGenerator.GetInt32(0, chars.Count),
                    randomChars[2][RandomNumberGenerator.GetInt32(0, randomChars[2].Length)]);

            if (requireNonAlphanumeric)
                chars.Insert(RandomNumberGenerator.GetInt32(0, chars.Count),
                    randomChars[3][RandomNumberGenerator.GetInt32(0, randomChars[3].Length)]);

            for (var i = chars.Count; i < requiredLength || chars.Distinct().Count() < requiredUniqueChars; i++)
            {
                var rcs = randomChars[RandomNumberGenerator.GetInt32(0, randomChars.Length)];
                chars.Insert(RandomNumberGenerator.GetInt32(0, chars.Count),
                    rcs[RandomNumberGenerator.GetInt32(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}
