using System;

namespace StockMarket.Shared.Models
{
    public class MarketStatus
    {
        public string Market { get; set; }
        public string Nyse { get; set; }
        public string Nasdaq { get; set; }
        public string Otc { get; set; }
        public DateTime ServerTime { get; set; }
    }
}