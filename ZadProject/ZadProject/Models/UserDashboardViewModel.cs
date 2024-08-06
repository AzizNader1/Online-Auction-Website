namespace ZadProject.Models
{
    public class UserDashboardViewModel
    {
        public UserDto User { get; set; }
        public AllUserBiding AllUserBiding { get; set; }
        public AllUserBuying AllUserBuying { get; set; }
        public int BidingNumber { get; set; }
        public int BuyingNumber { get; set;}
        public List<CarAuction> UserCarAuctions { get; set;}
        public List<OtherAuction> UserOtherAuctions { get; set;}
        public List<RealStateAuction> UserRealStateAuctions { get; set;}
    }

}
