namespace AuctionHouseAPI.Models
{
    public class ContractSales
    {
        public int Id { get; set; }
        public int ContractIndex { get; set; }
        public int ServiceLevelType { get;  set;}
        public int ServiceLevel { get; set; }
        public int ShelfLife { get; set; }
        public DateTime OrderDeadline { get; set; }
        public int TradeUnit { get; set; }  
        public int PaymentTerm { get; set; }
        public int PromotionalPressure { get; set; }
        public int PromotionHorizon { get; set; }


    }
}
