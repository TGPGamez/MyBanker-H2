using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.OldLib
{
    class VisaDankort : Card, IExpire
    {
        public VisaDankort(string cardHolderName) : base(cardHolderName)
        {
            this.LengthOfCard = 14;
            this.AgeLimit = 18;
            this.StartingNumbers = new string[]
            {
                "4"
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
