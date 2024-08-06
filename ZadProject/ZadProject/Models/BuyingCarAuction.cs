namespace ZadProject.Models
{
    public class BuyingCarAuction
    {
        public int BuyingCarAuctionId { get; set; }
        public int CarAuctionId { get; set; }
        public CarAuction CarAuction { get; set; }
        public int UserId { get; set; }
        public  User User { get; set; }
    }
}
