using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var ci = System.Globalization.CultureInfo.InvariantCulture;

            string sX0 = X0.Text.Trim();
            string sXk = Xk.Text.Trim();
            string sDx = Dx.Text.Trim();
            string sB = B.Text.Trim();

            if (string.IsNullOrWhiteSpace(sX0) || string.IsNullOrWhiteSpace(sXk) || string.IsNullOrWhiteSpace(sDx) || string.IsNullOrWhiteSpace(sB))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double x0, xk, dx, b;

            if (!double.TryParse(sX0.Replace(',', '.'), System.Globalization.NumberStyles.Any, ci, out x0))
            {
                MessageBox.Show($"Ошибка в x₀: '{sX0}'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!double.TryParse(sXk.Replace(',', '.'), System.Globalization.NumberStyles.Any, ci, out xk))
            {
                MessageBox.Show($"Ошибка в xₖ: '{sXk}'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!double.TryParse(sDx.Replace(',', '.'), System.Globalization.NumberStyles.Any, ci, out dx))
            {
                MessageBox.Show($"Ошибка в dx: '{sDx}'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!double.TryParse(sB.Replace(',', '.'), System.Globalization.NumberStyles.Any, ci, out b))
            {
                MessageBox.Show($"Ошибка в b: '{sB}'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверки
            if (dx <= 0)
            {
                MessageBox.Show("Шаг dx должен быть положительным!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double intervalLength = Math.Abs(xk - x0);
            if (dx > intervalLength)
            {
                MessageBox.Show($"Шаг dx ({dx}) больше длины интервала ({intervalLength})!\n" + "График будет содержать всего одну точку. Уменьшите шаг или увеличьте интервал.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (x0 > xk)
            {
                MessageBox.Show("x₀ должно быть меньше или равно xₖ!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

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
                    MessageBox.Show("Слишком много точек — уменьшите интервал или увеличьте шаг.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                }
            }

            if (ChartPayments.ChartAreas.Count > 0)
                ChartPayments.ChartAreas[0].RecalculateAxesScale();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            X0.Clear();
            Xk.Clear();
            Dx.Clear();
            B.Clear();
            GraficResult.Clear();
            ChartPayments.Series.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}


