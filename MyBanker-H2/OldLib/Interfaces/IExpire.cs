using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.OldLib
{
    interface IExpire
    {
        DateTime ExpirationDate { get; set; }
        void CalculateExpireDate();
    }
}
