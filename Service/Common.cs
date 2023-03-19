using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konscious.Security.Cryptography;

namespace Service
{
    public static class Common
    {
        const int memorySize = 1024;
        const int iterations = 10;
        public static string HashPassword(string password)
        {
            // Generate a random salt
            var salt = new byte[16];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Hash the password with the generated salt
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 4,// Số lượng luồng được sử dụng để tính toán
                Iterations = iterations,// Số lần lặp lại của thuật toán
                MemorySize = memorySize // 1 GB Kích thước bộ nhớ được sử dụng để tính toán
            };
            var hash = argon2.GetBytes(16);
            // Combine the salt and hash and return as a string
            var saltPlusHash = new byte[16 + hash.Length];
            Buffer.BlockCopy(salt, 0, saltPlusHash, 0, salt.Length);
            Buffer.BlockCopy(hash, 0, saltPlusHash, salt.Length, hash.Length);
            // Giải phóng bộ nhớ
            Array.Clear(salt, 0, salt.Length);
            Array.Clear(argon2.GetBytes(memorySize), 0, argon2.GetBytes(memorySize).Length);
            // Lưu trữ hash trong cơ sở dữ liệu để so sánh với mật khẩu sau này
            return Convert.ToBase64String(saltPlusHash);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Extract the salt and hash from the hashed password string
            var saltPlusHash = Convert.FromBase64String(hashedPassword);
            var salt = new byte[16];
            var hash = new byte[saltPlusHash.Length - 16];
            Buffer.BlockCopy(saltPlusHash, 0, salt, 0, salt.Length);
            Buffer.BlockCopy(saltPlusHash, salt.Length, hash, 0, hash.Length);

            // Compute the hash of the input password with the extracted salt
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 4,
                Iterations = iterations,
                MemorySize = memorySize // 1 GB
            };
            var computedHash = argon2.GetBytes(16);

            // Compare the computed hash with the extracted hash
            for (int i = 0; i < hash.Length; i++)
            {
                if (computedHash[i] != hash[i])
                {
                    Array.Clear(salt, 0, salt.Length);
                    Array.Clear(argon2.GetBytes(memorySize), 0, argon2.GetBytes(memorySize).Length);
                    return false;
                }
            }
            Array.Clear(salt, 0, salt.Length);
            Array.Clear(argon2.GetBytes(memorySize), 0, argon2.GetBytes(memorySize).Length);
            return true;
        }
    }
}
