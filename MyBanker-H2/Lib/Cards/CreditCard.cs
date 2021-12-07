using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.Lib
{
    public class CreditCard : Card
    {
        private double maxCreditUse;
        public double MaxCreditUse
        {
            get { return maxCreditUse; }
            protected set { maxCreditUse = value; }
        }

        private double creditUsed;
        public double CreditUsed
        {
            get { return creditUsed; }
            protected set { creditUsed = value; }
        }

        public CreditCard(Account account) : base(account)
        {
            this.creditUsed = 0;
        }


        /// <summary>
        /// Withdraws amount from Account balance if conditions is met
        /// and adds amount to usedCredit
        /// </summary>
        /// <param name="amount"></param>
        public override void WithdrawFromCard(double amount)
        {
            double canWithdraw = (maxCreditUse - creditUsed);
            if (this.Account.Balance >= amount)
            {
                if (amount <= canWithdraw)
                {
                    creditUsed += amount;
                    this.Account.Withdraw(amount);
                }
            }
        }

        /// <summary>
        /// Deposit amount to Account balance
        /// </summary>
        /// <param name="amount"></param>
        public override void DepositToCard(double amount)
        {
            this.Account.Deposit(amount);
        }
    }
}
