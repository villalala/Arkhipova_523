using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Arkhipova_523
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки "Вычислить" — функция 2
        /// </summary>
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtX.Text) ||
                    string.IsNullOrWhiteSpace(txtM.Text))
                {
                    MessageBox.Show("Заполните поля X и I!",
                        "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double x = double.Parse(txtX.Text.Replace(',', '.'));
                if (!int.TryParse(txtM.Text, out int i))
                {
                    MessageBox.Show("I должно быть целым числом!",
                        "Ошибка формата", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                double f = GetFValue(x);

                double result = CalculateFunction2(x, i, f);

                Result.Text = result.ToString("F6");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числа!",
                    "Ошибка формата", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Возвращает значение f(x) в зависимости от выбранного RadioButton
        /// </summary>
        private double GetFValue(double x)
        {
            if (rbSinh.IsChecked == true)
                return Math.Sinh(x);
            else if (rbX2.IsChecked == true)
                return x * x;
            else if (rbExp.IsChecked == true)
                return Math.Exp(x);
            else
                throw new InvalidOperationException("Не выбрана функция f(x)");
        }

        /// <summary>
        /// Чистая функция расчёта второй математической функции (кусочная)
        /// </summary>
        private double CalculateFunction2(double x, int i, double f)
        {
            bool iOdd = (i % 2 != 0);

            if (iOdd && x > 0)
            {
                if (f < 0)
                    throw new ArgumentException("f(x) отрицательно под корнем при x > 0 и нечётном i");

                return i * Math.Sqrt(f);
            }
            else if (!iOdd && x < 0)
            {
                return (i / 2.0) * Math.Sqrt(Math.Abs(f));
            }
            else
            {
                return Math.Sqrt(Math.Abs(f));
            }
        }

        /// <summary>
        /// Обработчик кнопки "Очистить"
        /// </summary>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtM.Clear();
            Result.Clear();
            rbSinh.IsChecked = true;
        }

        /// <summary>
        /// Переход на предыдущую страницу (Page1)
        /// </summary>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        /// <summary>
        /// Переход на следующую страницу (Page3)
        /// </summary>
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }
    }
}