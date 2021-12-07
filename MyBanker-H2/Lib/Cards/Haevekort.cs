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
            this.AgeLimit = 18;
            this.Prefixes = new string[]
            {
                "2400"
            };
            //Generate random cardNumber
            this.CardNumber = GenerateCardNumber();
        }

        public override string ToString()
        {
            return $"\nHolderName: {this.Account.HolderName}\n" +
                $"Card Number: {this.CardNumber}\nCVV: {this.CVV}\n";
        }

        /// <summary>
        /// Withdraws amount from Account balance if conditions is met
        /// </summary>
        /// <param name="amount"></param>
        public override void WithdrawFromCard(double amount)
        {
            if (this.Account.Balance >= amount)
            {
                this.Account.Withdraw(amount);
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
