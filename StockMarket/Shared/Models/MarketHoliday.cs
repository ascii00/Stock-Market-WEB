using System;

namespace StockMarket.Shared.Models
{
    public class MarketHoliday
    {
        public string Exchange { get; set; }
        public string HolidayName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}