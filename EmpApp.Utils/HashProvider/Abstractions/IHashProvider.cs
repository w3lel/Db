using System;
using System.Collections.Generic;
using System.Text;

namespace CyberAge.Utils.HashProvider.Abstractions
{
    public interface IHashProvider
    {
        /// <summary>
        /// Шифрование
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        string HashString(string inputString);

        /// <summary>
        /// Шифрование
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="hashString"></param>
        /// <returns></returns>
        string HashString(string inputString, string hashString);
    }
}
