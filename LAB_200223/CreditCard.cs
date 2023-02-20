using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_200223
{
    internal class CreditCard
    {
        private string cardNumber;
        private string ownerName;
        private DateTime validityPeriod;
        private string pin;
        private decimal creditLimit;
        private decimal balance;

        public event EventHandler RefillEvent;
        public event EventHandler ExpenditureEvent;
        public event EventHandler CreditUseStartEvent;
        public event EventHandler<decimal> BalanceThresholdEvent;
        public event EventHandler PinChangeEvent;

        public CreditCard(string cardNumber, string ownerName, DateTime validityPeriod, string pin, decimal creditLimit, decimal balance = 0)
        {
            this.cardNumber = cardNumber;
            this.ownerName = ownerName;
            this.validityPeriod = validityPeriod;
            this.pin = pin;
            this.creditLimit = creditLimit;
            this.balance = balance;
        }

        public void Refill(decimal amount)
        {
            balance += amount;
            RefillEvent?.Invoke(this, EventArgs.Empty);
        }

        public void Expenditure(decimal amount)
        {
            balance -= amount;
            ExpenditureEvent?.Invoke(this, EventArgs.Empty);
        }

        public void StartCreditUse()
        {
            CreditUseStartEvent?.Invoke(this, EventArgs.Empty);
        }

        public void CheckBalanceThreshold(decimal threshold)
        {
            if (balance >= threshold)
            {
                BalanceThresholdEvent?.Invoke(this, balance);
            }
        }

        public void ChangePin(string newPin)
        {
            pin = newPin;
            PinChangeEvent?.Invoke(this, EventArgs.Empty);
        }

        public string CardNumber
        {
            get { return cardNumber; }
        }

        public string OwnerName
        {
            get { return ownerName; }
        }

        public DateTime ValidityPeriod
        {
            get { return validityPeriod; }
        }

        public decimal CreditLimit
        {
            get { return creditLimit; }
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public override string ToString()
        {
            return 
                $"\n\t{cardNumber}\n" +
                $"\t{ownerName}\n" +
                $"\t{validityPeriod}\n" +
                $"\t{pin}\n" +
                $"\t{creditLimit}\n" +
                $"\t{balance}\n";
        }
    }
}
