using System;


namespace MyWebApi.Models
{
    public class CriptoCoinVM
    {
        public int ID { get; set; }

        public long Time { get; set; }

        public string PriceUsd { get; set; }
    }
}
