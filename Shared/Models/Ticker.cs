using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace StockMarket.Shared.Models
{
    public class Ticker
    {
        [JsonProperty("ticker")]
        public string TickerAbb { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("market")]
        public string Market { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("primary_exchange")]
        public string PrimaryExchange { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("currency_name")]
        public string CurrencyName { get; set; }
        [JsonProperty("cik")]
        public string Cik { get; set; }
        [JsonProperty("composite_figi")]
        public string CompositeFigi { get; set; }
        [JsonProperty("share_class_figi")]
        public string ShareClassFigi { get; set; }
        [JsonProperty("last_updated_utc")]
        public DateFormat LastUpdatedUtc { get; set; }
    }
}