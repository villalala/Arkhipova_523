using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arkhipova_523
{
    /// <summary>
    /// Страница графического интерфейса для шифрования и дешифрования алгоритмом ROT13.
    /// Реализует валидацию ввода, обработку исключений и документирование кода.
    /// </summary>
    public partial class Page1 : Page
    {
        private readonly Rot13Encryptor _encryptor = new Rot13Encryptor();
        private readonly Rot13Decryptor _decryptor = new Rot13Decryptor();

        /// <summary>
        /// Инициализирует компоненты интерфейса.
        /// </summary>
        public Page1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Зашифровать".
        /// Выполняет валидацию, шифрование и отображение результата.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void BtnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearError();
                string input = txtInput.Text;

                if (string.IsNullOrWhiteSpace(input))
                {
                    ShowError("Введите текст для шифрования.");
                    txtInput.Focus();
                    return;
                }

                string result = _encryptor.Encrypt(input);
                txtOutput.Text = result;
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка шифрования: {ex.Message}");
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Дешифровать".
        /// Выполняет валидацию, дешифрование и отображение результата.
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void btnDecrypt_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearError();
                string input = txtInput.Text;

                if (string.IsNullOrWhiteSpace(input))
                {
                    ShowError("Введите шифротекст для дешифрования.");
                    txtInput.Focus();
                    return;
                }

                string result = _decryptor.Decrypt(input);
                txtOutput.Text = result;
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка дешифрования: {ex.Message}");
            }
        }

        /// <summary>
        /// Отображает сообщение об ошибке в интерфейсе.
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        private void ShowError(string message)
        {
            txtError.Text = message;
            txtError.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Скрывает сообщение об ошибке и очищает текст.
        /// </summary>
        private void ClearError()
        {
            txtError.Visibility = Visibility.Collapsed;
            txtError.Text = string.Empty;
        }
    }
}