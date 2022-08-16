using System.Threading.Tasks;

namespace StockMarket.Server.Services
{
    public interface IStockService
    {
        public Task<string?> GetJsonFromUrl(string url);
    }
}