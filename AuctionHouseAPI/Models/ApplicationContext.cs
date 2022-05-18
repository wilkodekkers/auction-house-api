using Microsoft.EntityFrameworkCore;

namespace AuctionHouseAPI.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
