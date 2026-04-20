## Архипова Василиса 3ИСИП-523 Практическая работа №7 ❤️
#### Дисциплина: Поддержка и тестирование программных модулей

# **ОТЛАДКА ПРОГРАММЫ РАЗЛИЧНЫМИ СПОСОБАМИ"** 

### Цель работы
произвести процедуру отладки программного обеспечения встроенными средствами среды программирования Microsoft Visual Studio.

### Ход работы
В предоставленном коде была ошибка, которая исправлялась в ходе выполнения отладки 

```
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
```

### Используемые способы отладки
- Останавливают выполнение в нужном месте (например, внутри метода SendMessage).
Пошаговое выполнение
- F10 — шаг с обходом (Step Over)
- F11 — шаг с заходом в метод (Step Into)
- Shift + F11 — выйти из метода (Step Out)

Просмотр значений
- Наводим курсор на переменную (name, letters[i] и др.) — видим её текущее значение.
Окна отладчика
- Locals — все локальные переменные
- Watch — добавляем нужные выражения для наблюдения
- Autos — переменные с текущей строки

Запуск отладки
- Fn + F5 — запуск в режиме отладки
- Ctrl + Shift + Fn + F5 — перезапуск

Стек вызовов
- Показывает последовательность: Main() → SendMessage().
