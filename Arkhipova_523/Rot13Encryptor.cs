using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkhipova_523
{
    public class Rot13Encryptor
    {
        /// <summary>
        /// Шифрует входную строку сдвигом на 13 позиций.
        /// Неалфавитные символы (цифры, пробелы, кириллица, знаки препинания) остаются без изменений.
        /// </summary>
        /// <param name="text">Исходный текст для шифрования</param>
        /// <returns>Зашифрованная строка</returns>
        public string Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= 'A' && chars[i] <= 'Z')
                    chars[i] = (char)('A' + (chars[i] - 'A' + 13) % 26);
                else if (chars[i] >= 'a' && chars[i] <= 'z')
                    chars[i] = (char)('a' + (chars[i] - 'a' + 13) % 26);
            }
            return new string(chars);
        }
    }
}
