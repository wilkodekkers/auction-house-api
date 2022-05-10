using Microsoft.EntityFrameworkCore;

namespace AuctionHouseAPI.Models
{
    public class AuctionContext : DbContext
    {
        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
        {

        }

        public DbSet<Auction> Auctions { get; set; }
    }
}
