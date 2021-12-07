using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.Lib
{
    public class VisaElectron : Card, IExpire, IDebetCard
    {
        public VisaElectron(Account account) : base(account)
        {
            expire = DateTime.Now.AddYears(5);
            this.LengthOfCard = 14;
            this.AgeLimit = 15;
            this.Prefixes = new string[]
            {
                "4026", "417500", "4508", "4844", "4913", "4917"
            };
            //Generate random cardNumber
            this.CardNumber = GenerateCardNumber();
        }

        private DateTime expire;
        public DateTime ExpirationDate { get => expire; set => expire = value; }

        public override string ToString()
        {
            return $"\nHolderName: {this.Account.HolderName}\n" +
                $"Card Number: {this.CardNumber}\nCVV: {this.CVV}\n" +
                $"Expire date: {expire.ToString()}\n";
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
