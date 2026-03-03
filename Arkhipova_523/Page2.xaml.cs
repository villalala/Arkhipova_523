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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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

            double f = 0;
            if (rbSinh.IsChecked == true)
            {
                f = Math.Sinh(x);
            }
            else if (rbX2.IsChecked == true)
            {
                f = x * x;
            }
            else if (rbExp.IsChecked == true)
            {
                f = Math.Exp(x);
            }
            else
            {
                MessageBox.Show("Выберите одну из функций f(x)!",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double e_value;
            bool i_odd = (i % 2 != 0);

            if (i_odd && x > 0)
            {
                if (f < 0)
                {
                    MessageBox.Show("f(x) отрицательно под корнем при x > 0 и нечётном i!",
                        "Ошибка домена", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                e_value = i * Math.Sqrt(f);
            }
            else if (!i_odd && x < 0)
            {
                e_value = (i / 2.0) * Math.Sqrt(Math.Abs(f));
            }
            else
            {
                e_value = Math.Sqrt(Math.Abs(f));
            }

            Result.Text = e_value.ToString("F6");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtM.Clear();
            Result.Clear();
            rbSinh.IsChecked = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }
    }
}
