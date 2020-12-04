using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CyberAge.Domain.Services.Users.Utils
{
    public class UserUtil
    {
        /// <summary>
        /// Ключ для шифрования
        /// </summary>
        public static string Key;

        /// <summary>
        /// Шифрование
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string HashPassword(string password)
        {
            var keyBytes = Encoding.UTF8.GetBytes(Key);

            byte[] encryptedBytes = null;
            using (var chipherAlgorithm = Aes.Create())
            {
                if (chipherAlgorithm != null)
                {
                    chipherAlgorithm.BlockSize = 128;
                    chipherAlgorithm.Key = keyBytes;
                    chipherAlgorithm.Mode = CipherMode.CBC;
                    chipherAlgorithm.IV = keyBytes;
                    var encryptor = chipherAlgorithm.CreateEncryptor(chipherAlgorithm.Key, chipherAlgorithm.IV);
                    using (var encryptStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(encryptStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (var streamWriter = new StreamWriter(cryptoStream))
                            {
                                streamWriter.Write(password);
                            }

                            encryptedBytes = encryptStream.ToArray();
                        }
                    }
                }
            }

            return encryptedBytes != null ? Convert.ToBase64String(encryptedBytes) : string.Empty;
        }
    }
}
