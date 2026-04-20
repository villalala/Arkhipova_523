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

namespace Galaxyy
{
    class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// Выводит приветствие и запускает вывод информации о галактиках.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Galaxy News!");
            IterateThroughList();
            Console.ReadKey();
        }

        /// <summary>
        /// Создаёт список галактик и выводит информацию о каждой из них в консоль.
        /// </summary>
        private static void IterateThroughList()
        {
            var theGalaxies = new List<Galaxy>
        {
            new Galaxy() { Name="Tadpole", MegaLightYears=400, GalaxyType=new GType('S')},
            new Galaxy() { Name="Pinwheel", MegaLightYears=25, GalaxyType=new GType('S')},
            new Galaxy() { Name="Cartwheel", MegaLightYears=500, GalaxyType=new GType('L')},
            new Galaxy() { Name="Small Magellanic Cloud", MegaLightYears=.2, GalaxyType=new GType('I')},
            new Galaxy() { Name="Andromeda", MegaLightYears=3, GalaxyType=new GType('S')},
            new Galaxy() { Name="Maffei 1", MegaLightYears=11, GalaxyType=new GType('E')}
        };

            foreach (Galaxy theGalaxy in theGalaxies)
            {
                Console.WriteLine(theGalaxy.Name + "  " + theGalaxy.MegaLightYears + ",  " + theGalaxy.GalaxyType.MyGType);
            }

            // Expected Output:
            //  Tadpole  400,  Spiral
            //  Pinwheel  25,  Spiral
            //  Cartwheel, 500,  Lenticular
            //  Small Magellanic Cloud .2,  Irregular
            //  Andromeda  3,  Spiral
            //  Maffei 1,  11,  Elliptical
        }
    }

    /// <summary>
    /// Представляет галактику с основными характеристиками.
    /// </summary>
    public class Galaxy
    {
        /// <summary>
        /// Название галактики
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Расстояние до галактики в мега-световых годах
        /// </summary>
        public double MegaLightYears { get; set; }
        
        /// <summary>
        /// Тип галактики
        /// </summary>
        public GType GalaxyType { get; set; }

    }

    /// <summary>
    /// Класс, отвечающий за тип галактики.
    /// Преобразует символ в соответствующее текстовое описание типа.
    /// </summary>
    public class GType
    {
        /// <summary>
        /// Инициализирует тип галактики на основе переданного символа.
        /// </summary>
        /// <param name="type">Символ типа галактики: 
        /// 'S' - Spiral, 
        /// 'E' - Elliptical, 
        /// 'I' - Irregular, 
        /// 'L' - Lenticular
        /// </param>
        public GType(char type)
        {
            switch (type)
            {
                case 'S':
                    MyGType = Type.Spiral;
                    break;
                case 'E':
                    MyGType = Type.Elliptical;
                    break;
                case 'I':
                    MyGType = Type.Irregular;
                    break;
                case 'L': 
                    MyGType = Type.Lenticular;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Текстовое представление типа галактики
        /// </summary>
        public object MyGType { get; set; }

        /// <summary>
        /// Внутреннее перечисление возможных типов галактик
        /// </summary>
        private enum Type { Spiral, Elliptical, Irregular, Lenticular }
    }
}
```

### Используемые способы отладки
- Точки останова - для пошагового выполнения кода. останавливает в определённом, потенциально проблемном моменте
- Пошаговая (построчная) отладка с особым вниманием циклу for и его возвращаемому результату
- F10 (Step Over) — выполнить строку и перейти к следующей
- F11 (Step Into) — зайти внутрь метода или конструктора
