namespace ZadProject.Models
{
    public class BuyingRealStateAuction
    {
        public int BuyingRealStateAuctionId { get; set; }
        public int RealStateAuctinoId { get; set; }
        public RealStateAuction RealStateAuction { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
