using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.Lib
{
    public abstract class Card
    {
        private Account account;
        protected Account Account
        {
            get { return account; }
            private set { account = value; }
        }

        private string cardNumber;
        protected string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        private string cvv;
        protected string CVV
        {
            get { return cvv; }
            private set { cvv = value; }
        }

        private int lengthOfCard;
        protected int LengthOfCard
        {
            get { return lengthOfCard; }
            set { lengthOfCard = value; }
        }


        private string[] prefixes;
        protected string[] Prefixes
        {
            get { return prefixes; }
            set { prefixes = value; }
        }


        public Card(Account account)
        {
            this.Prefixes = prefixes;
            this.account = account;
            this.cvv = GenerateCVV();
        }


        public abstract void WithdrawFromCard(double amount);
        public abstract void DepositToCard(double amount);


        protected string GenerateCardNumber()
        {
            string prefix = Prefixes[new Random().Next(0, Prefixes.Length)];
            string generatedNumber = prefix;
            for (int i = 0; i < LengthOfCard - prefix.Length; i++)
            {
                generatedNumber += new Random(Guid.NewGuid().GetHashCode()).Next(0, 10);
            }
            return generatedNumber;
        }

        private string GenerateCVV()
        {
            string generatedCVV = String.Empty;
            for (int i = 0; i < 3; i++)
            {
                generatedCVV += new Random(Guid.NewGuid().GetHashCode()).Next(0, 10);
            }
            return generatedCVV;
        }
    }
}
