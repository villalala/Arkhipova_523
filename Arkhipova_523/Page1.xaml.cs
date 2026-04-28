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
    
    internal static class Rot13Logic
    {
        public static string Process(string text)
        {
            char[] arr = text.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsLetter(arr[i]))
                {
                    char offset = char.IsUpper(arr[i]) ? 'A' : 'a';
                    arr[i] = (char)(offset + (arr[i] - offset + 13) % 26);
                }
            }
            return new string(arr);
        }
    }
}