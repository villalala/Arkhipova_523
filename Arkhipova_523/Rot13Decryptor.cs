using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkhipova_523
{
    /// <summary>
    /// Класс для дешифрования текста алгоритмом ROT13.
    /// </summary>
    public class Rot13Decryptor
    {
        /// <summary>
        /// Дешифрует текст. Поскольку ROT13 симметричен, вызывает метод шифрования.
        /// </summary>
        /// <param name="cipher">Шифротекст</param>
        /// <returns>Исходный текст</returns>
        public string Decrypt(string cipher)
        {
            return new Rot13Encryptor().Encrypt(cipher);
        }
    }
}
