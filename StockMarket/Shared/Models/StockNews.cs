using System;

namespace StockMarket.Shared.Models
{
    public class StockNews
    {
        public string Title { get; set; }
        public string PublisherName { get; set; }
        public string Description { get; set; }
        public string ArticleUrl { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}