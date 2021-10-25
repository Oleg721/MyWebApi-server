using System;

namespace DTO
{
    public class CurrencyHistoryDto 
    {
        public int ID { get; set; }
        public String Timestamp { get; set; }

        public float BidPrice { get; set; }

        public float AskPrice { get; set; }

        public float BidVolum { get; set; }

        public float AskVolum { get; set; }

        public int CurrencyID { get; set; }

    }
}
