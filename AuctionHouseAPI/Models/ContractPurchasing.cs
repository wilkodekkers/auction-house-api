namespace AuctionHouseAPI.Models
{
    public class ContractPurchasing
    {
        public int Id { get; set; }
        public int ContractIndex { get; set; }
        public Quality Quality { get; set; }
        public int LeadTime { get; set; }
        public bool Certification { get; set; }
        public Country Country { get; set; }
        public Transport TransportMode { get; set; }
        public int FreeCapacity { get; set; }
        public int PaymentTerms { get; set; }
        public Unit TradeUnit { get ; set; } 
        public int AgreedDeliveryReliability { get; set; }
        public int DeliveryWindow { get; set; }
    }
}
