using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Arkhipova_523
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки "Вычислить" — функция 1
        /// </summary>
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtX.Text) ||
                    string.IsNullOrWhiteSpace(txtY.Text) ||
                    string.IsNullOrWhiteSpace(txtZ.Text))
                {
                    MessageBox.Show("Все поля (x, y, z) должны быть заполнены!",
                        "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double x = double.Parse(txtX.Text.Replace(',', '.'));
                double y = double.Parse(txtY.Text.Replace(',', '.'));
                double z = double.Parse(txtZ.Text.Replace(',', '.'));

                if (y <= 0)
                {
                    MessageBox.Show("y должно быть строго больше 0 (иначе логарифм не определён)!",
                        "Ошибка домена", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                double result = CalculateFunction1(x, y, z);
                Result.Text = result.ToString("F6");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числа!\n(используйте точку или запятую)",
                    "Ошибка формата", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Чистая функция расчёта первой математической функции
        /// </summary>
        public double CalculateFunction1(double x, double y, double z)
        {
            double absoluteX = Math.Abs(x);
            double yPowered = Math.Pow(y, -Math.Sqrt(absoluteX));
            double lnPart = Math.Log(yPowered);
            double secondPart = x - y / 2.0;
            double sinSquared = Math.Pow(Math.Sin(Math.Atan(z)), 2);

            return lnPart * secondPart + sinSquared;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtZ.Clear();
            Result.Clear();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}