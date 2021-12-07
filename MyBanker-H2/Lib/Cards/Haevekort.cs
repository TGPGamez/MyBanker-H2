using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.Lib
{
    public class Haevekort : Card, IDebetCard
    {
        public Haevekort(Account account) : base(account)
        {
            this.LengthOfCard = 14;
            this.Prefixes = new string[]
            {
                "2400"
            };
            this.CardNumber = GenerateCardNumber();
        }

        public override string ToString()
        {
            return $"\nHolderName: {this.Account.AccountHolderName}\n" +
                $"Card Number: {this.CardNumber}\nCVV: {this.CVV}\n";
        }

        public override void WithdrawFromCard(double amount)
        {
            if (this.Account.Balance >= amount)
            {
                this.Account.Withdraw(amount);
            }
        }

        public override void DepositToCard(double amount)
        {
            this.Account.Deposit(amount);
        }
    }
}
