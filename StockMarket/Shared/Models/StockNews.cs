namespace StockMarket.Shared.Models
{
    public class StockNews
    {
        public string Ticker { get; set; }
        public string Title { get; set; }
        public string PublisherName { get; set; }
        public string Description { get; set; }
        public string ArticleUrl { get; set; }
    }
}