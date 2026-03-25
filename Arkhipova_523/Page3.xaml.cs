using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Navigation;

namespace Arkhipova_523
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();

            if (ChartPayments.ChartAreas.Count == 0)
            {
                ChartPayments.ChartAreas.Add(new ChartArea("Main"));

                var title = new Title("y = x⁴ + cos(2 + x³ - b)");
                title.Docking = Docking.Top;
                title.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
                title.ForeColor = System.Drawing.Color.Black;
                ChartPayments.Titles.Add(title);
            }
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!TryGetInput(out double x0, out double xk, out double dx, out double b))
                    return;

                if (dx <= 0)
                {
                    MessageBox.Show("Шаг dx должен быть положительным!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (x0 > xk)
                {
                    MessageBox.Show("x₀ должно быть меньше или равно xₖ!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                PerformTabulation(x0, xk, dx, b);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числа!", "Ошибка формата", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool TryGetInput(out double x0, out double xk, out double dx, out double b)
        {
            x0 = xk = dx = b = 0;

            string sX0 = X0.Text.Trim();
            string sXk = Xk.Text.Trim();
            string sDx = Dx.Text.Trim();
            string sB = B.Text.Trim();

            if (string.IsNullOrWhiteSpace(sX0) || string.IsNullOrWhiteSpace(sXk) ||
                string.IsNullOrWhiteSpace(sDx) || string.IsNullOrWhiteSpace(sB))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            var ci = System.Globalization.CultureInfo.InvariantCulture;

            return double.TryParse(sX0.Replace(',', '.'), System.Globalization.NumberStyles.Any, ci, out x0) &&
                   double.TryParse(sXk.Replace(',', '.'), System.Globalization.NumberStyles.Any, ci, out xk) &&
                   double.TryParse(sDx.Replace(',', '.'), System.Globalization.NumberStyles.Any, ci, out dx) &&
                   double.TryParse(sB.Replace(',', '.'), System.Globalization.NumberStyles.Any, ci, out b);
        }

        /// <summary>
        /// Основная логика табулирования и построения графика
        /// </summary>
        public void PerformTabulation(double x0, double xk, double dx, double b)
        {
            ChartPayments.Series.Clear();
            GraficResult.Clear();

            var series = new Series("y(x)")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = System.Drawing.Color.DarkBlue,
                ChartArea = "Main"
            };
            ChartPayments.Series.Add(series);

            double x = x0;
            int pointCount = 0;

            while (x <= xk + 1e-10)
            {
                double y = Math.Pow(x, 4) + Math.Cos(2 + Math.Pow(x, 3) - b);
                series.Points.AddXY(x, y);
                GraficResult.AppendText($"x = {x,10:F4}    y = {y,12:F6}\n");

                x += dx;
                pointCount++;

                if (pointCount > 5000)
                {
                    MessageBox.Show("Слишком много точек — уменьшите интервал или увеличьте шаг.",
                        "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                }
            }

            if (ChartPayments.ChartAreas.Count > 0)
                ChartPayments.ChartAreas[0].RecalculateAxesScale();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            X0.Clear();
            Xk.Clear();
            Dx.Clear();
            B.Clear();
            GraficResult.Clear();
            ChartPayments.Series.Clear();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Вы действительно хотите выйти из приложения?",
                "Подтверждение выхода",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);

            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}