using MiNET.Utils;

namespace AuctionHouseAPI.Models
{
    public class Auction
    {
        public UUID Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AuctionType auctiontype { get; set; }
    }
}
