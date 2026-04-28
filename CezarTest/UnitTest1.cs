using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arkhipova_523;

namespace Rot13Test
{
    [TestClass]
    public class Rot13AutomationTests
    {
        [TestMethod]
        public void TC_FUN_1_LowercaseLetters()
        {
            var encryptor = new Rot13Encryptor();
            string result = encryptor.Encrypt("hello");
            Assert.AreEqual("uryyb", result, "Строчные буквы зашифрованы неверно");
        }

        [TestMethod]
        public void TC_FUN_2_MixedCase()
        {
            var encryptor = new Rot13Encryptor();
            string result = encryptor.Encrypt("AbCdEf");
            Assert.AreEqual("NoPqRs", result, "Регистр не сохранён или сдвиг неверный");
        }

        [TestMethod]
        public void TC_FUN_3_SelfInverse()
        {
            var encryptor = new Rot13Encryptor();
            var decryptor = new Rot13Decryptor();

            string original = "Testing123";
            string encrypted = encryptor.Encrypt(original);
            string decrypted = decryptor.Decrypt(encrypted);

            Assert.AreEqual(original, decrypted, "Двойное применение ROT13 не вернуло исходный текст");
        }

        [TestMethod]
        public void TC_FUN_4_IgnoreNonAlphabetic()
        {
            var encryptor = new Rot13Encryptor();
            string result = encryptor.Encrypt("Hello, World! 2026 @#");
            Assert.AreEqual("Uryyb, Jbeyq! 2026 @#", result, "Неалфавитные символы были изменены или удалены");
        }

        [TestMethod]
        public void TC_NEG_1_EmptyString()
        {
            var encryptor = new Rot13Encryptor();
            string result = encryptor.Encrypt("");
            Assert.AreEqual("", result, "Пустая строка должна возвращать пустой результат без исключений");
        }
    }
}