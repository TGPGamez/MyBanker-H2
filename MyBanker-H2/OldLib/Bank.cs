using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.OldLib
{
    public abstract class Bank
    {
        Card[] cardsOfferedByBank =
        {
            new Haevekort("Hævekort"),
            new Maestro("Maestro"),
            new VisaElectron("Visa Electron"),
            new VisaDankort("Visa / Dankort"),
            new MasterCard("MasterCard")
        };

        private string bankAccountNumber;

        public string BankAccountNumber
        {
            get { return bankAccountNumber; }
            private set { bankAccountNumber = value; }
        }

        public Bank(string bankAccountNumber)
        {
            this.BankAccountNumber = bankAccountNumber;
        }


        public string ShowOfferedCards(int age)
        {
            string temp = String.Empty;
            foreach (Card card in cardsOfferedByBank)
            {
                if (card.AgeLimit <= age || (card is Haevekort && age < card.AgeLimit))
                {
                    temp += card.CardHolderName + "\n";
                }
            }
            return temp;
        }

        public Card GiveCard(string cardName, string cardHolderName, string offers)
        {
            if (!offers.Contains(cardName))
            {
                return null;
            }
            Card tempCard = null;
            foreach (Card card in cardsOfferedByBank)
            {
                if (card.CardHolderName == cardName)
                {
                    card.CardHolderName = cardHolderName;
                    tempCard = card;
                }
            }
            tempCard.GenerateCard();
            tempCard.AddBankAccountNumber(BankAccountNumber);
            return tempCard;
        }
    }
}
