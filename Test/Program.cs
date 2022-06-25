using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var API_KEY = "&apiKey=5NZpIQoLjjL1VNEANjr3EnNqQpWZw9yw";
            var url = $"https://api.polygon.io/v3/reference/tickers?active=true&sort=ticker&order=asc{API_KEY}";
            
            var list = new List<Ticker>();
            var i = 0;
            
            while (true)
            {
                var httpClient = new HttpClient();
                var result = await httpClient.GetAsync(url);

                if (!result.IsSuccessStatusCode)
                    break;

                var data = await result.Content.ReadAsStringAsync();


                var json = JObject.Parse(data);

                var tickers = json["results"]
                    .Select(token => token["ticker"].Value<string>())
                    .ToArray();
                
                url = json["next_url"].ToString()+API_KEY;
                Console.WriteLine(url);

                list.AddRange(tickers.Select(ticker => new Ticker {Id = i++, Name = ticker}));

                Sleep(300);
                //https://api.polygon.io/v3/reference/tickers?sort=ticker&ticker.gte=D&ticker.lt=E&apiKey=5NZpIQoLjjL1VNEANjr3EnNqQpWZw9yw
            }

            foreach (var ticker in list)
                Console.WriteLine(ticker.Id +" " + ticker.Name);
        }
    }
}