using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Arkhipova_523
{
    /// <summary>
    /// Логика взаимодействия для первой страницы приложения.
    /// Реализует расчёт математической функции №1 (вариант 5).
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Вычислить".
        /// Выполняет валидацию введённых данных, производит расчёт функции 1
        /// и выводит результат в поле Result.
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
                MessageBox.Show("Введите корректные числа!\n(используйте точку или запятую как разделитель)",
                    "Ошибка формата", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка:\n{ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Чистая функция расчёта первой математической функции (вариант 5).
        /// Формула: a = ln(y^(-√|x|)) * (x - y/2) + sin²(arctan(z))
        /// </summary>
        /// <param name="x">Значение переменной x</param>
        /// <param name="y">Значение переменной y (должно быть > 0)</param>
        /// <param name="z">Значение переменной z</param>
        /// <returns>Результат вычисления функции</returns>
        public double CalculateFunction1(double x, double y, double z)
        {
            double absoluteX = Math.Abs(x);
            double yPowered = Math.Pow(y, -Math.Sqrt(absoluteX)); 
            double lnPart = Math.Log(yPowered);
            double secondPart = x - y / 2.0;
            double sinSquared = Math.Pow(Math.Sin(Math.Atan(z)), 2);

            return lnPart * secondPart + sinSquared;
        }

        /// <summary>
        /// Обработчик кнопки "Очистить".
        /// Очищает все поля ввода и поле результата.
        /// </summary>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtZ.Clear();
            Result.Clear();
        }

        /// <summary>
        /// Переход на следующую страницу (Page2).
        /// </summary>
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}