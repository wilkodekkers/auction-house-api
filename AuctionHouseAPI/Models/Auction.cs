namespace AuctionHouseAPI.Models
{
    public class Auction
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AuctionType Auctiontype { get; set; }

        public Bottlingline? BottlingLine { get; set; }
    }
}
