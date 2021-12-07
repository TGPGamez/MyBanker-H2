using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.Lib
{
    public class AccountManager
    {
        //private Guid customerID;
        //public Guid CustomerID
        //{
        //    get { return customerID; }
        //    private set { customerID = value; }
        //}

        private Account account;
        public Account Account
        {
            get { return account; }
            private set { account = value; }
        }

        private List<Card> cards;

        public List<Card> Cards
        {
            get { return cards; }
            private set { cards = value; }
        }

        public AccountManager(string holderName, int age)
        {
            this.account = new Account(holderName, age);
            this.cards = new List<Card>();
        }


        /// <summary>
        /// Add a card to to Cards
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(Card card)
        {
            this.cards.Add(card);
        }

        /// <summary>
        /// Finds specific card out from cardNumber and returns card
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public Card GetCard(string cardNumber)
        {
            foreach (Card card in cards)
            {
                if (card.CardNumber == cardNumber)
                {
                    return card;
                }
            }
            return null;
        }

    }
}
