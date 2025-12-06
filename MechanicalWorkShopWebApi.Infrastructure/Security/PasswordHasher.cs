using System.Security.Cryptography;
using System.Text;

namespace MechanicalWorkShopWebApi.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public bool VerifyPasswordHash(string password, byte[] storedPHash, byte[] storedPSalt)
        {
            if (string.IsNullOrEmpty(password))
                return false;
            if (storedPHash.Length != 64)
                return false;
            if (storedPSalt.Length != 120)
                return false;

            using (var hmac = new HMACSHA3_512(storedPSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(storedPHash);
            }
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA3_512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
