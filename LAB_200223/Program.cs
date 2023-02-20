using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_200223
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard card = new CreditCard("1234567890123456", "John Doe", new DateTime(2023, 12, 31), "1234", 1000);

            card.RefillEvent += (sender, e) => Console.WriteLine("\tRefill event was triggered.");
            card.ExpenditureEvent += (sender, e) => Console.WriteLine("\tExpenditure event was triggered.");
            card.CreditUseStartEvent += (sender, e) => Console.WriteLine("\tCredit use start event was triggered.");
            card.BalanceThresholdEvent += (sender, balance) => Console.WriteLine($"\tBalance threshold event was triggered. Balance: {balance}");
            card.PinChangeEvent += (sender, e) => Console.WriteLine("\tPIN change event was triggered.");

            Console.WriteLine(card.ToString());

            card.Refill(500);
            card.Expenditure(300);
            card.ChangePin("4321");
            card.CheckBalanceThreshold(400);

            Console.WriteLine(card.ToString());

            Console.ReadKey();
        }
    }
}
