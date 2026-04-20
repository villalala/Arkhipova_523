using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    internal class Program
    {
        /// <summary>
        /// Вычисляет n-е число Фибоначчи итеративным способом.
        /// </summary>
        /// <param name="n">Номер числа Фибоначчи (начиная с 0)</param>
        /// <returns>n-е число последовательности Фибоначчи</returns>
        static int Fibonacci(int n)
        {
            Console.WriteLine("The output is: ");
            int n1 = 0;
            int n2 = 1;
            int sum;

            for (int i = 2; i <= n; i++)
            {
                sum = n1 + n2;
                n1 = n2;
                n2 = sum;
            }

            return n == 0 ? n1 : n2;
        }

        /// <summary>
        /// Точка входа в приложение.
        /// Вычисляет и выводит 5-е число Фибоначчи.
        /// </summary>
        static void Main(string[] args)
        {
            int result = Fibonacci(5);
            Console.WriteLine(result);
        }
    }
}
