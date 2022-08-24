using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StockMarket.Server.Models;
using StockMarket.Shared.Models;

namespace StockMarket.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        
        public DbSet <FavouriteCompany> FavouriteCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FavouriteCompany>(e =>
            {
                e.HasKey(e1 => new
                {
                    e1.UserId,
                    e1.Ticker
                });
                e.Property(e1 => e1.CompanyName).HasMaxLength(100).IsRequired();
                e.Property(e1 => e1.Ticker).HasMaxLength(100).IsRequired();
                e.Property(e1 => e1.City).HasMaxLength(100).IsRequired();
                e.Property(e1 => e1.AddingDate).IsRequired();
                e.ToTable("FavouriteTickers");
            });
        }
    }
}
