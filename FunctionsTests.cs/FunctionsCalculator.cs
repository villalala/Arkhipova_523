using Arkhipova_523;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FunctionsTests.cs
{
    [TestClass]
    public class FunctionsCalculator
    {
        [TestMethod]
        public void CalculateFunction1_ValidInput_ReturnsCorrectResult()
        {
            var page1 = new Page1();
            double x = 2;
            double y = 3;
            double z = 1;
            double expected = -0.276836;

            double actual = page1.CalculateFunction1(x, y, z);

            Assert.AreEqual(expected, actual, 0.001, "Функция 1 рассчитана неверно");
        }

        [TestMethod]
        public void CalculateFunction2_ValidInput_ReturnsCorrectResult()
        {
            var page = new Page2();
            double f = Math.Sinh(4);
            double result = page.CalculateFunction2(4, 3, f);
            Assert.AreEqual(15.671916, result, 0.001, "Функция 2 посчитана неверно");
        }

        [TestMethod]
        public void CalculateY_ValidInput_ReturnsCorrectResult()
        {
            double x = -1.0;
            double b = 0.0;
            double expected = Math.Pow(-1, 4) + Math.Cos(2 + Math.Pow(-1, 3) - b);

            double actual = Math.Pow(x, 4) + Math.Cos(2 + Math.Pow(x, 3) - b);

            Assert.AreEqual(expected, actual, 0.001, "Функция 3 посчитана неверно");
        }
    }
}
