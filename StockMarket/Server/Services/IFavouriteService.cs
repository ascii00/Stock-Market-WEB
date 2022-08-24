using System.Collections.Generic;
using System.Threading.Tasks;
using StockMarket.Server.Models;
using StockMarket.Shared.Models;

namespace StockMarket.Server.Services
{
    public interface IFavouriteService
    {
        public Task<string> AddCompanyToFavourite(FavouriteCompany company);
        public Task<string> RemoveCompanyFromFavourites(FavouriteCompany company);
        public Task<bool> CheckCompanyOnFavourite(FavouriteCompany company);
        public Task<IEnumerable<FavouriteCompany>> GetAllFavouritesCompanies(string userId);
    }
}