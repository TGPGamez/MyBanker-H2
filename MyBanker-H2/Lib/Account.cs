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
        public string HolderName
        {
            get { return accountHolderName; }
            private set { accountHolderName = value; }
        }

        private int accountHolderAge;
        public int HolderAge
        {
            get { return accountHolderAge; }
            private set { accountHolderAge = value; }
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

        public Account(string holderName, int age)
        {
            this.accountHolderName = holderName;
            this.accountHolderAge = age;
            this.regNr = "3520";
            this.accountNumber = GenerateAccountNumber();
            this.Balance = 0;

        }

        /// <summary>
        /// Generate a AccountNumber that is 10 characters long
        /// </summary>
        /// <returns></returns>
        private string GenerateAccountNumber()
        {
            string generatedNumber = String.Empty;
            for (int i = 0; i < 10; i++)
            {
                generatedNumber += new Random(Guid.NewGuid().GetHashCode()).Next(0, 10);
            }
            return generatedNumber;
        }


        /// <summary>
        /// Withdraws from balance
        /// </summary>
        /// <param name="amount"></param>
        public void Withdraw(double amount) 
        {
            balance -= amount;
        }

        /// <summary>
        /// Deposits to balance
        /// </summary>
        /// <param name="amount"></param>
        public void Deposit(double amount)
        {
            balance += amount;
        }
    }
}
