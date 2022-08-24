using System;

namespace StockMarket.Shared.Models
{
    public class FavouriteCompany
    {
        public string UserId { get; set; }
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public DateTime AddingDate { get; set; }
    }
}