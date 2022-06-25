using System.Collections.Generic;
using System.Threading.Tasks;
using StockMarket.Shared.Models;

namespace StockMarket.Server.Services
{
    public interface IStockService
    {
        public Task<string> GetTickers();
    }
}