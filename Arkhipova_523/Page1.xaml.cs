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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

                double absX = Math.Abs(x);
                double sqrtAbsX = Math.Sqrt(absX);
                double exponent = -sqrtAbsX;
                double yPow = Math.Pow(y, exponent); 
                double lnPart = Math.Log(yPow); 

                double bracket = x - y / 2.0; 

                double atanZ = Math.Atan(z);
                double sinAtan = Math.Sin(atanZ);
                double sin2 = sinAtan * sinAtan; 

                double a = lnPart * bracket + sin2;

                Result.Text = a.ToString("F6");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числа!\n(используйте точку или запятую как разделитель)",
                    "Ошибка формата", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое/маленькое число — переполнение!",
                    "Ошибка вычисления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка:\n{ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtZ.Clear();
            Result.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
    
}
