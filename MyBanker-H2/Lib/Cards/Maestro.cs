﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.Lib
{
    public class Maestro : Card, IExpire, IDebetCard
    {
        public Maestro(Account account) : base(account)
        {
            expire = DateTime.Now.AddYears(5).AddMonths(8);
            this.LengthOfCard = 19;
            this.AgeLimit = 18;
            this.Prefixes = new string[]
            {
                "5018", "5020", "5038", "5893",  "6304", "6759", "6761", "6762", "6763"
            };
            //Generate random cardNumber
            this.CardNumber = GenerateCardNumber();
        }

        private DateTime expire;
        public DateTime ExpirationDate { get => expire; set => expire = value; }

        public override string ToString()
        {
            return $"\nHolderName: {this.Account.HolderName}\n" +
                $"Card Number: {this.CardNumber}\n" +
                $"CVV: {this.CVV}\n" +
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
