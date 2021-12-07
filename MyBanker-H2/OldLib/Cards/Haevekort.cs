using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.OldLib
{
    class Haevekort : Card
    {
        public Haevekort(string cardHolderName) : base(cardHolderName)
        {
            this.LengthOfCard = 14;
            this.AgeLimit = 18;
            this.StartingNumbers = new string[] { "2400" };
        }

        public override string ToString()
        {
            return this.CardHolderName + " card with number " + this.CardNumber;
        }
    }
}
