using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExample
{
    class ArrayExample
    {
        /// <summary>
        /// Точка входа в программу.
        /// Демонстрирует работу с массивом символов, формирование строки и вызов метода.
        /// </summary>
        static void Main()
        {
            char[] letters = { 'f', 'r', 'e', 'd', ' ', 's', 'm', 'i', 't', 'h' };
            string name = "";
            int[] a = new int[10];
            for (int i = 0; i < letters.Length; i++)
            {
                name += letters[i];
                a[i] = i + 1;
                SendMessage(name, a[i]);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Выводит приветственное сообщение с именем и числом.
        /// </summary>
        /// <param name="name">Имя, которое будет выведено в сообщении</param>
        /// <param name="msg">Число, которое будет показано после "Count to"</param>
        static void SendMessage(string name, int msg)
        {
            Console.WriteLine("Hello, " + name + "! Count to " + msg);
        }
    }
}
