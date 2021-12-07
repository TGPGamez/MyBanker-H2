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
        protected double MaxCreditUse
        {
            get { return maxCreditUse; }
            set { maxCreditUse = value; }
        }

        private double creditUsed;
        protected double CreditUsed
        {
            get { return creditUsed; }
            set { creditUsed = value; }
        }

        public CreditCard(Account account) : base(account)
        {
            this.creditUsed = 0;
        }


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

        public override void DepositToCard(double amount)
        {
            this.Account.Deposit(amount);
        }
    }
}
