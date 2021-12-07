using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker_H2.Lib
{
    interface IExpire
    {
        public DateTime ExpirationDate { get; set; }
    }
}
