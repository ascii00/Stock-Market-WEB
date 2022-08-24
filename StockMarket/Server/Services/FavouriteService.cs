using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockMarket.Server.Data;
using StockMarket.Server.Models;
using System.Linq;
using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore;
using StockMarket.Shared.Models;

namespace StockMarket.Server.Services
{
    public class FavouriteService : IFavouriteService
    {

        private readonly ApplicationDbContext _context;

        public FavouriteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddCompanyToFavourite(FavouriteCompany company)
        {
            try
            {
                await _context.AddAsync(company);
                await _context.SaveChangesAsync();
                return "Added";
            }
            catch (Exception)
            {
                return "Error during communication with database.";
            }
        }

        public async Task<string> RemoveCompanyFromFavourites(FavouriteCompany company)
        {
            try
            {
                _context.FavouriteCompanies.Remove(company);
                await _context.SaveChangesAsync();
                return "Removed";
            }
            catch (Exception)
            {
                return "Error during communication with database.";
            }
        }

        public async Task<bool> CheckCompanyOnFavourite(FavouriteCompany company)
        {
            var idUser = await _context.FavouriteCompanies
                .Where(e1 => e1.UserId == company.UserId
                             && e1.Ticker == company.Ticker)
                .Select(e1 => e1.UserId)
                .FirstOrDefaultAsync();
            
            return idUser is not null;
        }

        public async Task<IEnumerable<FavouriteCompany>> GetAllFavouritesCompanies(string userId)
        {
            return await _context.FavouriteCompanies
                .Where(e1 => e1.UserId == userId)
                .Select(e => new FavouriteCompany()
                {
                    UserId = e.UserId,
                    Ticker = e.Ticker,
                    CompanyName = e.CompanyName,
                    City = e.City,
                    AddingDate = e.AddingDate
                }).ToListAsync();
        }
    }
}