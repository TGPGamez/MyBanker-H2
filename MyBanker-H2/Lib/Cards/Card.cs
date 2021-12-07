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
        public Account Account
        {
            get { return account; }
            protected set { account = value; }
        }

        private int ageLimit;
        public int AgeLimit
        {
            get { return ageLimit; }
            protected set { ageLimit = value; }
        }

        private string cardNumber;
        public string CardNumber
        {
            get { return cardNumber; }
            protected set { cardNumber = value; }
        }

        private string cvv;
        public string CVV
        {
            get { return cvv; }
            protected set { cvv = value; }
        }

        private int lengthOfCard;
        public int LengthOfCard
        {
            get { return lengthOfCard; }
            protected set { lengthOfCard = value; }
        }


        private string[] prefixes;
        public string[] Prefixes
        {
            get { return prefixes; }
            protected set { prefixes = value; }
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
