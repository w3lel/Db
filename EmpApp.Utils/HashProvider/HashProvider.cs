using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CyberAge.Utils.HashProvider.Abstractions;

namespace CyberAge.Utils.HashProvider
{
    /// <summary>
    /// Провайдер хеширования
    /// </summary>
    public class HashProvider : IHashProvider
    {
        /// <summary>
        /// Ключ для шифрования
        /// </summary>
        public string Key { get; set; } = "t6oSn8g7n6TRSp58";


        ///<inheritdoc/>
        public string HashString(string inputString)
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
                                streamWriter.Write(inputString);
                            }

                            encryptedBytes = encryptStream.ToArray();
                        }
                    }
                }
            }

            return encryptedBytes != null ? Convert.ToBase64String(encryptedBytes) : string.Empty;
        }

        ///<inheritdoc/>
        public string HashString(string inputString, string hashString)
        {
            var keyBytes = Encoding.UTF8.GetBytes(hashString);

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
                                streamWriter.Write(inputString);
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
