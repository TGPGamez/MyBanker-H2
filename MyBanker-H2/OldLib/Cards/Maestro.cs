using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.OldLib
{
    class Maestro : Card, IExpire
    {
        public Maestro(string cardHolderName) : base(cardHolderName)
        {
            this.LengthOfCard = 19;
            this.AgeLimit = 18;
            this.StartingNumbers = new string[]
            {
                "5018", "5020", "5038", "5893",  "6304", "6759", "6761", "6762", "6763"
            };
        }

        private DateTime expire;
        public DateTime ExpirationDate { get => expire; set => expire = value; }

        public void CalculateExpireDate()
        {
            ExpirationDate = DateTime.Now.AddYears(5);
            ExpirationDate.AddMonths(8);
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
