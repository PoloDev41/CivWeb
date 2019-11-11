using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebCiv.DAL
{
    /// <summary>
    /// class to handle password generation
    /// </summary>
    public static class Password_handler
    {
        /// <summary>
        /// number of iteration
        /// </summary>
        private static int passwordIteration = 10000;
        /// <summary>
        /// key size
        /// </summary>
        private static int keySize = 16;
        /// <summary>
        /// size of the salt
        /// </summary>
        private static int saltSize = 16;
        /// <summary>
        /// crypte the password
        /// </summary>
        /// <param name="password">password to crypt</param>
        /// <returns>crypted password</returns>
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


        /// <summary>
        /// check if a crypted password is the same than a uncrypted password
        /// </summary>
        /// <param name="hash">crypted</param>
        /// <param name="password">uncrypted</param>
        /// <returns>true: passwords are the same</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "code from internet")]
        public static bool Check(string hash, string password)
        {
            if(String.IsNullOrEmpty(hash) || String.IsNullOrEmpty(password))
            {
                throw new FormatException("hash or password is/are empty");
            }

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
