using System;
using System.Windows;
using System.Windows.Controls;

namespace Arkhipova_523
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// Калькулятор дохода по банковскому вкладу (Вариант №4).
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Главный метод расчёта дохода по вкладу.
        /// Используется как кнопкой "Вычислить", так и в автотестах.
        /// </summary>
        /// <param name="sum">Сумма вклада (руб.)</param>
        /// <param name="months">Срок вклада в месяцах</param>
        /// <param name="annualRate">Годовая процентная ставка (%)</param>
        /// <param name="isSimple">true — простые проценты, false — сложные проценты</param>
        /// <returns>Сумма дохода по вкладу</returns>
        public double CalculateIncome(double sum, int months, double annualRate, bool isSimple)
        {
            double monthlyRate = annualRate / 100 / 12;

            if (isSimple)
            {
                // Простые проценты
                return sum * monthlyRate * months;
            }
            else
            {
                // Сложные проценты
                double finalAmount = sum * Math.Pow(1 + monthlyRate, months);
                return finalAmount - sum;
            }
        }

        /// <summary>
        /// Обработчик кнопки "Вычислить".
        /// Выполняет проверку данных и выводит результат дохода.
        /// </summary>
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!TryParseInputs(out double sum, out int months, out double annualRate))
                return;

            bool isSimple = rbSimple.IsChecked == true;

            double income = CalculateIncome(sum, months, annualRate, isSimple);

            txtResult.Text = income.ToString();
        }

        /// <summary>
        /// Проверяет все поля ввода и преобразует их в числа.
        /// Если данные некорректны — показывает сообщение об ошибке.
        /// </summary>
        /// <param name="sum">Сумма вклада</param>
        /// <param name="months">Срок в месяцах</param>
        /// <param name="annualRate">Годовая ставка в процентах </param>
        /// <returns>True — если все данные корректны, иначе False</returns>
        private bool TryParseInputs(out double sum, out int months, out double annualRate)
        {
            sum = 0;
            months = 0;
            annualRate = 0;

            if (string.IsNullOrWhiteSpace(txtSum.Text) ||
                !double.TryParse(txtSum.Text.Replace(',', '.'), out sum) || sum <= 0)
            {
                MessageBox.Show("Сумма вклада должна быть положительным числом!",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMonth.Text) ||
                !int.TryParse(txtMonth.Text, out months) || months <= 0)
            {
                MessageBox.Show("Срок должен быть положительным целым числом!",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProc.Text) ||
                !double.TryParse(txtProc.Text.Replace(',', '.'), out annualRate) || annualRate <= 0)
            {
                MessageBox.Show("Процентная ставка должна быть положительным числом!",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}