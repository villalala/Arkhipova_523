using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Arkhipova_523;

namespace VkladTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Simple_Correct()
        {
            var page = new Page1();
            double result = page.CalculateIncome(100000, 12, 12, true);
            Assert.AreEqual(12000, result, 0.01, "Простые проценты рассчитаны неверно");
        }

        [TestMethod]
        public void Compound_Correct()
        {
            var page = new Page1();
            double result = page.CalculateIncome(100000, 12, 12, false);
            Assert.AreEqual(12682.5, result, 0.01, "Сложные проценты рассчитаны неверно");
        }

        [TestMethod]
        public void NegativeSum_Test()
        {
            var page = new Page1();
            double result = page.CalculateIncome(-50000, 12, 10, true);
            Assert.AreEqual(-5000, result, 0.01, "При отрицательной сумме доход должен быть отрицательным");
        }

        [TestMethod]
        public void ZeroMonths_Test()
        {
            var page = new Page1();
            double result = page.CalculateIncome(100000, 0, 12, true);
            Assert.AreEqual(0, result, 0.01);
        }

        [TestMethod]
        public void ZeroProc_Test()
        {
            var page = new Page1();
            double result = page.CalculateIncome(100000, 12, 0, true);
            Assert.AreEqual(0, result, 0.01);
        }
    }
}

