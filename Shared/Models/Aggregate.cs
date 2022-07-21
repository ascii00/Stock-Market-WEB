using Newtonsoft.Json;

namespace StockMarket.Shared.Models
{
    public class Aggregate
    {
        [JsonProperty("v")]
        public string Volume { get; set; }
        [JsonProperty("vw")]
        public string VolumeWeight { get; set; }
        [JsonProperty("o")]
        public string Open { get; set; }
        [JsonProperty("c")]
        public string Close { get; set; }
        [JsonProperty("h")]
        public string High { get; set; }
        [JsonProperty("l")]
        public string Low { get; set; }
        [JsonProperty("t")]
        public bool Time { get; set; }
        [JsonProperty("n")]
        public string Number { get; set; }
    }
}