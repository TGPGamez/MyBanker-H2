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
            expire = CalculateExpirationDate(5, 0);
            this.LengthOfCard = 14;
            this.AgeLimit = 18;
            this.MaxCreditUse = 25000;
            this.Prefixes = new string[]
            {
                "4"
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
                $"Expire date: {expire.ToString()}\n" +
                $"Credit withdraw: {this.CreditUsed}/{this.MaxCreditUse}\n";
        }

        /// <summary>
        /// Calculates expire date out from parameters
        /// </summary>
        /// <param name="years"></param>
        /// <param name="months"></param>
        /// <returns></returns>
        public DateTime CalculateExpirationDate(int years, int months)
        {
            DateTime dateTime = DateTime.Now;
            dateTime.AddYears(years);
            dateTime.AddMonths(months);
            return dateTime;
        }
    }
}
