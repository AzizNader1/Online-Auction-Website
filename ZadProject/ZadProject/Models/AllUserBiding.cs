namespace ZadProject.Models
{
    public class AllUserBiding
    {
        public List<BidingCarAuctionDto> BidingCarAuctionDto { get; set; }
        public List<BidingOtherAuctionDto> BidingOtherAuctionDto { get; set; }
        public List<BidingRealStateAuctionDto> BidingRealStateAuctionDto { get; set; }
    }
}
