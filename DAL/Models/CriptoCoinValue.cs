using System;


namespace Dal.Models
{
    public class CriptoCoinValue: BaseEntity<int>
    {
        public long Time { get; set; }

        public string PriceUsd { get; set; }
    }
}
