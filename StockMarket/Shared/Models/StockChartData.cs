using System;

namespace StockMarket.Shared.Models
{
    public class StockChartData
    {
        public DateTime Date { get; set; } // t
        public Double Open { get; set; }  // o
        public Double Low { get; set; }  // l
        public Double Close { get; set; } // c
        public Double High { get; set; } // h
        public Double Volume { get; set; } // v
    }
}