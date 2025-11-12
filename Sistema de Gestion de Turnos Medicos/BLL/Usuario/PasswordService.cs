using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; // Agregamos esta libreria para poder usar los metodos de hash

namespace BLL
{
    public class PasswordService : IPasswordService
    {

        private const int SaltSize = 16; // 16 BYTES
        private const int HashSize = 32; // 32 BYTES
        private const int Iterations = 100; 

        public string HashPassword(string plainpassword)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(plainpassword, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);
                
                return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
            }
        }

        public bool VerifyPassword(string plainpassword, string storedHash)
        {
            try
            {

                var parts = storedHash.Split('.');
                if (parts.Length != 3) return false;

                int iterations = int.Parse(parts[0]);
                byte[] salt =Convert.FromBase64String(parts[1]);
                byte[] hash = Convert.FromBase64String(parts[2]);

                using(var pbkdf2 = new Rfc2898DeriveBytes(plainpassword, salt, iterations, HashAlgorithmName.SHA256))
                {
                    byte[] computed = pbkdf2.GetBytes(HashSize);
                    return FixedTimeEquals(computed, hash);
                }

            }
            catch
            {
                return false;
            }
        }
        private bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];

            return diff == 0;
        }

    }
}
