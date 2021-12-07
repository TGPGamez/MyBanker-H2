using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.Lib
{
    public class Account
    {
        private string accountHolderName;
        public string AccountHolderName
        {
            get { return accountHolderName; }
            private set { accountHolderName = value; }
        }


        private string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }
            private set { accountNumber = value; }
        }

        private string regNr;
        public string RegNr
        {
            get { return regNr; }
            private set { regNr = value; }
        }

        private double balance;
        public double Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        public Account(string holderName)
        {
            this.accountHolderName = holderName;
            this.regNr = "3520";
            this.accountNumber = GenerateAccountNumber();
            this.Balance = 0;

        }

        private string GenerateAccountNumber()
        {
            string generatedNumber = String.Empty;
            for (int i = 0; i < 10; i++)
            {
                generatedNumber += new Random(Guid.NewGuid().GetHashCode()).Next(0, 10);
            }
            return generatedNumber;
        }

        public void Withdraw(double amount) 
        {
            balance -= amount;
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }
    }
}
