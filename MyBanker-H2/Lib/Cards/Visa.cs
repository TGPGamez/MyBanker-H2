using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.Lib
{
    public class Visa : CreditCard, IExpire
    {
        public Visa(Account account) : base(account)
        {
            expire = DateTime.Now.AddYears(5);
            this.LengthOfCard = 14;
            this.MaxCreditUse = 25000;
            this.Prefixes = new string[]
            {
                "4"
            };
            this.CardNumber = GenerateCardNumber();
        }

        private DateTime expire;
        public DateTime ExpirationDate { get => expire; set => expire = value; }

        public override string ToString()
        {
            return $"\nHolderName: {this.Account.AccountHolderName}\n" +
                $"Card Number: {this.CardNumber}\nCVV: {this.CVV}\n" +
                $"Expire date: {expire.ToString()}\n" +
                $"Credit withdraw: {this.CreditUsed}/{this.MaxCreditUse}\n";
        }
    }
}
