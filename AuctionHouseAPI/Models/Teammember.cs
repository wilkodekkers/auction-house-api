namespace AuctionHouseAPI.Models
{
    public class Teammember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Mail { get; set; }
        public string Wachtwoord { get; set; }
        public string Role { get; set; }
    }
}
