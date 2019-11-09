using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebCiv.DAL
{
    public static class Password_handler
    {
        private static int passwordIteration = 10000;
        private static int keySize = 16;
        private static int saltSize = 16;
        public static string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              saltSize,
              passwordIteration,
              HashAlgorithmName.SHA256))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{passwordIteration}.{salt}.{key}";
            }
        }

        public static bool Check(string hash, string password)
        {
            var parts = hash.Split('.', 3);

            if (parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format. " +
                  "Should be formatted as `{iterations}.{salt}.{hash}`");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              salt,
              iterations,
              HashAlgorithmName.SHA256))
            {
                var keyToCheck = algorithm.GetBytes(keySize);

                var verified = keyToCheck.SequenceEqual(key);

                return verified;
            }
        }
    }
}
