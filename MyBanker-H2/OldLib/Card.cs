using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.OldLib
{
    public abstract class Card
    {
        private string cardHolderName;
        public string CardHolderName
        {
            get { return cardHolderName; }
            set { cardHolderName = value; }
        }

        private int ageLimit;
        public int AgeLimit
        {
            get { return ageLimit; }
            set { ageLimit = value; }
        }

        private int lengthOfCard;
        public int LengthOfCard
        {
            get { return lengthOfCard; }
            set { lengthOfCard = value; }
        }

        private string cardNumber;
        public string CardNumber
        {
            get { return cardNumber; }
            protected set { cardNumber = value; }
        }

        private string[] startingNumbers;
        public string[] StartingNumbers
        {
            get { return startingNumbers; }
            set { startingNumbers = value; }
        }

        public Card(string cardHolderName)
        {
            this.CardHolderName = cardHolderName;
            this.StartingNumbers = startingNumbers;
            this.AgeLimit = ageLimit;
        }

        string prefix;
        public virtual void GenerateCard()
        {
            prefix = StartingNumbers[new Random().Next(0, StartingNumbers.Length)];
            cardNumber += prefix;
            for (int i = 0; i < LengthOfCard - prefix.Length; i++)
            {
                cardNumber += new Random(Guid.NewGuid().GetHashCode()).Next(0, 10);
            }
            PrettifyCard();
        }

        private void PrettifyCard()
        {
            for (int i = 4; i < LengthOfCard + prefix.Length; i += 5)
            {
                cardNumber = cardNumber.Insert(i, " ");
            }
        }

        public void AddBankAccountNumber(string bankAccounterNumber)
        {
            CardNumber = CardNumber.Insert(0, bankAccounterNumber + " ");
        }
    }
}
