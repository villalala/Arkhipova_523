using System;

namespace BankAccountNS
{
    /// <summary>
    /// Класс, представляющий банковский счёт клиента.
    /// Демонстрационный пример для изучения unit-тестирования.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Сообщение об ошибке: сумма списания превышает доступный баланс.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Сообщение об ошибке: сумма списания отрицательная.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        /// <summary>
        /// Сообщение об ошибке: сумма пополнения отрицательная.
        /// </summary>
        public const string CreditAmountLessThanZeroMessage = "Credit amount cannot be negative";


        /// <summary>
        /// Закрытый конструктор по умолчанию, запрещающий создание объекта без параметров.
        /// </summary>
        private BankAccount() { }


        /// <summary>
        /// Инициализирует новый экземпляр банковского счёта.
        /// </summary>
        /// <param name="customerName">Имя владельца счёта</param>
        /// <param name="balance">Начальный баланс счёта</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }


        /// <summary>
        /// Имя владельца банковского счёта (только для чтения).
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
        }


        /// <summary>
        /// Текущий баланс счёта (только для чтения).
        /// </summary>
        public double Balance
        {
            get { return m_balance; }
        }


        /// <summary>
        /// Снимает указанную сумму со счёта.
        /// </summary>
        /// <param name="amount">Сумма для списания (должна быть положительной и не превышать текущий баланс)</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если <paramref name="amount"/> больше текущего баланса или отрицательное значение
        /// </exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }


        /// <summary>
        /// Пополняет счёт на указанную сумму.
        /// </summary>
        /// <param name="amount">Сумма пополнения (должна быть неотрицательной)</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если <paramref name="amount"/> меньше нуля.
        /// </exception>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    amount,
                    CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }


        /// <summary>
        /// Точка входа демонстрационной программы.
        /// Создаёт тестовый счёт, выполняет несколько операций и выводит итоговый баланс.
        /// </summary>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);

            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}