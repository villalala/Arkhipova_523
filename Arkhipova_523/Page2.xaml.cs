using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Arkhipova_523
{
    /// <summary>
    /// Логика взаимодействия для второй страницы приложения (Page2).
    /// Реализует расчёт кусочной математической функции №2 (вариант 5).
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки "Вычислить".
        /// Выполняет проверку введённых данных, определяет f(x), 
        /// производит расчёт кусочной функции и выводит результат.
        /// </summary>
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtX.Text) || string.IsNullOrWhiteSpace(txtM.Text))
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
                MessageBox.Show($"Ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Возвращает значение f(x) в зависимости от выбранного переключателя (RadioButton).
        /// </summary>
        /// <param name="x">Значение переменной x</param>
        /// <returns>Значение выбранной функции f(x)</returns>
        private double GetFValue(double x)
        {
            if (rbSinh.IsChecked == true)
                return Math.Sinh(x);

            if (rbX2.IsChecked == true)
                return x * x;

            if (rbExp.IsChecked == true)
                return Math.Exp(x);

            throw new InvalidOperationException("Не выбрана функция f(x)");
        }

        /// <summary>
        /// Чистая функция расчёта второй математической функции (кусочная).
        /// Формула: e = { i√f(x) если i нечётное и x > 0; 
        ///             i/2 √|f(x)| если i чётное и x < 0; 
        ///             √|f(x)| иначе }
        /// </summary>
        /// <param name="x">Значение переменной x</param>
        /// <param name="i">Целое число i</param>
        /// <param name="f">Значение функции f(x)</param>
        /// <returns>Результат вычисления функции e</returns>
        public double CalculateFunction2(double x, int i, double f)
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
        /// Обработчик кнопки "Очистить".
        /// Очищает поля ввода, результат и сбрасывает выбор RadioButton.
        /// </summary>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtM.Clear();
            Result.Clear();
            rbSinh.IsChecked = true;
        }

        /// <summary>
        /// Переход на предыдущую страницу (Page1).
        /// </summary>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        /// <summary>
        /// Переход на следующую страницу (Page3).
        /// </summary>
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }
    }
}