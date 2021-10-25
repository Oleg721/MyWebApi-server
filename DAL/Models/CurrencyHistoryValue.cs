using System;


namespace Dal.Models
{
    public class CurrencyHistoryValue : BaseEntity<int>
    {

        public String Timestamp { get; set; }

        public float BidPrice { get; set; }

        public float AskPrice { get; set; }

        public float BidVolum { get; set; }

        public float AskVolum { get; set; }

        public CurrencyValue Currency { get; set; }

    }
}
