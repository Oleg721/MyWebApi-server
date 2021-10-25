using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public class CurrencyValue : BaseEntity<int>
    {
        public String Name { get; set; }

        public virtual ICollection<CurrencyHistoryValue> CurrencyHistoryValues { get; set; }

    }
}
