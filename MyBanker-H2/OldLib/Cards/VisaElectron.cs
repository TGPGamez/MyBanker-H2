using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.OldLib
{
    class VisaElectron : Card, IExpire
    {
        public VisaElectron(string cardHolderName) : base(cardHolderName)
        {
            this.LengthOfCard = 16;
            this.AgeLimit = 15;
            this.StartingNumbers = new string[]
            {
                "4026", "417500", "4508", "4844", "4913", "4917"
            };
        }

        private DateTime expire;
        public DateTime ExpirationDate { get => expire; set => expire = value; }

        public void CalculateExpireDate()
        {
            ExpirationDate = DateTime.Now.AddYears(5);
        }

        public override void GenerateCard()
        {
            CalculateExpireDate();
            base.GenerateCard();
        }

        public override string ToString()
        {
            return this.CardHolderName + " card with number " + this.CardNumber + ". Expires " + this.ExpirationDate.ToString();
        }
    }
}
